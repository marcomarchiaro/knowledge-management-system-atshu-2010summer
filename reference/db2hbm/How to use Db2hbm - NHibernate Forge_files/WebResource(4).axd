function RateableContentYesNoRating (varName, containerId, imageId, percentId, percentTextId, buttonsId, thanksId, containerCssClass, containerActiveCssClass, callbackFunction) 
{
	this._variableName = varName;
	this._isReadOnly = false;
	this._containerHandle = document.getElementById(containerId);
	this._imageHandle = document.getElementById(imageId);
	this._percentHandle = document.getElementById(percentId);
	this._percentTextHandle = document.getElementById(percentTextId);
	this._buttonsHandle = document.getElementById(buttonsId);
	this._thanksHandle = document.getElementById(thanksId);
	this._containerCssClass = containerCssClass;
	this._containerActiveCssClass = containerActiveCssClass;
	this._callbackFunction = callbackFunction;
	
	this._setAnimationHandle = null;
	this._savingValue = false;
	
	this.SetValue = function (value)
	{
		if (this._isReadOnly || this._savingValue)
			return;
		
		if (this.SetAnimationHandle)
			window.clearTimeout(this._setAnimationHandle);
			
		this._savingValue = true;
		this._callbackFunction(value, new Function('result', 'window.' + this._variableName + '._valueSaved(result);'), new Function("alert('An error occured while saving the rating value.');"));
			
		this._setAnimationHandle = window.setTimeout(this._variableName + "._setAnimation(0);", 99);
	}
	
	this._valueSaved = function(result)
	{
		result = eval(result);
	
	    this._isReadOnly = true;
	    
	    if (result[0] > 0)
	    {
	        if (this._imageHandle)
	        {
	            if (result[2])
	            {
	                this._imageHandle.src = result[2];
	                this._imageHandle.style.display = 'inline';
	            }
	            else
	                this._imageHandle.style.display = 'none';
            }

            if (this._percentHandle)
            {    	        
	            this._percentHandle.innerHTML = result[3];
	            this._percentHandle.style.display = 'inline';
	        }
	    }
	    else
	    {
	        if (this._imageHandle)
	            this._imageHandle.style.display = 'none';
	            
            if (this._percentHandle)
	            this._percentHandle.style.display = 'none';
	    }

        this._containerHandle.title = result[1];
        
        if (this._percentTextHandler)
	        this._percentTextHandle.innerHTML = result[4];
	    
	    if (this._buttonsHandle)
	        this._buttonsHandle.style.display = 'none';
	        
	    if (this._thanksHandle)
	        this._thanksHandle.style.display='inline';
					
		this._savingValue = false;
	}
	
	this._setAnimation = function (step)
	{
		if (step > 6)
			return;
			
		if (step % 2 == 0)
			this._containerHandle.className = this._containerCssClass;
		else
			this._containerHandle.className = this._containerActiveCssClass;

		if (!this._savingValue)
			step = step + 1;
		else
			step = (step + 1) % 2;
			
		this._setAnimationHandle = window.setTimeout(this._variableName + "._setAnimation(" + step + ");", 199);
	}
}