function WikiPageHierarchy (varName, ajaxFunction, expandHtml, collapseHtml, loadingMarkup)
{
	this._variableName = varName;
	this._ajaxFunction = ajaxFunction;
	this._expandHtml = expandHtml;
	this._collapseHtml = collapseHtml;
	
	this._loadingElement = null;
	this._loadingPageId = null;

    this._expand = function(pageId, element)
    {
        if (element.parentNode.childNodes.length == 3)
        {
            element.parentNode.childNodes[2].style.display = 'block';
            element.onclick = new Function(this._variableName + '._collapse(\'' + pageId + '\', this); return false');
            element.innerHTML = this._collapseHtml;
        }
        else
        {
            var le = document.createElement('div');
            le.innerHTML = loadingMarkup;
            element.parentNode.appendChild(le);
            element.onclick = new Function('return false');
            this._loadingElement = element;
            this._loadingPageId = pageId;
            
            this._ajaxFunction('getchildren', pageId, new Function('result', 'window.' + this._variableName + '._expandCallback(result);'));
        }
    }
    
    this._expandCallback = function(html)
    {
        if (html)
        {
            if (this._loadingElement && this._loadingPageId)
            {
                var element = this._loadingElement;
                this._loadingElement = null;
                
                var pageId = this._loadingPageId;
                this._loadingPageId = null;
        
                element.parentNode.childNodes[2].innerHTML = html;
                element.parentNode.childNodes[2].style.display = 'block';
                element.onclick = new Function(this._variableName + '._collapse(\'' + pageId + '\', this); return false');
                element.innerHTML = this._collapseHtml;
            }
        }
    }
    
    this._collapse = function(pageId, element)
    {
        if (element.parentNode.childNodes.length == 3)
        {
            element.parentNode.childNodes[2].style.display = 'none';
            element.onclick = new Function(this._variableName + '._expand(\'' + pageId + '\', this); return false');
            element.innerHTML = this._expandHtml;
        }
    }
}