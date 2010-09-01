// JavaScript Document

$(document).ready(function () {
            $(".flip").click(function () {
                $(".panel", this.parentNode).slideToggle("middle");
            });
            $("div .panel").each(function (i) { this.style.backgroundColor = ['#fff', '#eee'][i % 2] });
        });

  $(document).ready(function () {
            var Option = { url: 'search',
                beforeSubmit: showRequest,
                success: function () {
                    alert("success!");
                }
            };
            $("div .sideSearch").hide();
            $("#logo").css("background", "none");
            $("#SearchFm").submit(function () {
                $(this).ajaxSubmit(Option);
                return true;
            });
        });
        function showRequest(formData, jqForm, options) {
            // formData is an array; here we use $.param to convert it to a string to display it 
            // but the form plugin does this for you automatically when it submits the data 
            var queryString = $.param(formData);

            // jqForm is a jQuery object encapsulating the form element.  To access the 
            // DOM element for the form do this: 
            // var formElement = jqForm[0]; 

            alert('string to send: \n\n' + queryString);

            // here we could return false to prevent the form from being submitted; 
            // returning anything other than false will allow the form submit to continue 
            return true;
        }