function logoCentering()
{

	var rbcLogo = document.getElementById("rbcSystemIdentifierLogo");

	if ( rbcLogo.parentNode.className == "image" )
	{

		var elImg = rbcLogo.firstChild;

		if (elImg && elImg.offsetHeight == 0)
		{
			Event.observe(window, 'load', function (e)
				{
					setTimeout(logoCentering, 1000);
				}

			);
			return false;
		}

		offsetTop = parseInt(( 60 - elImg.offsetHeight ) / 2 );
		if ( offsetTop > 0 )
		{
			rbcLogo.parentNode.style.overflow = "visible";
			rbcLogo.firstChild.style.position = "relative";
			rbcLogo.firstChild.style.top = offsetTop + "px";
		}
	}
}
