	function success(position) {
				  var s = document.querySelector('#status');
				  
				  if (s.className == 'success') {
					// not sure why we're hitting this twice in FF, I think it's to do with a cached result coming back    
					return;
				  }
				  
				s.className = 'success';
				  
				var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
				  
				reverseGeoCoding(latlng);
			   
			 
			 
			 
			  var myOptions = {
				zoom: 15,
				center: latlng,
				mapTypeControl: false,
				navigationControlOptions: {style: google.maps.NavigationControlStyle.SMALL},
				mapTypeId: google.maps.MapTypeId.ROADMAP
			  };
			  
			  var map = new google.maps.Map(document.getElementById("mapcanvas"), myOptions);
			  
			  
			  var marker = new google.maps.Marker({
				  position: latlng, 
				  map: map, 
				  title:"You are here! (at least within a "+position.coords.accuracy+" meter radius)"
			  });
				}
			
				function reverseGeoCoding(latlng){
				   var geocoder = new google.maps.Geocoder();
				   geocoder.geocode({'latLng': latlng}, function(results, status) {
					if (status == google.maps.GeocoderStatus.OK) {
					  if (results[0]) {
						var address=results[0].address_components;
						
						var st = document.getElementById('st');
						var city = document.getElementById('city');
						var code = document.getElementById('code');
						var country = document.getElementById('country');
						
						st.value=address[0].long_name+" " + address[1].long_name;
						city.value=address[2].long_name;
						code.value=address[address.length - 1].long_name;
						country.value=address[5].long_name;
						
					  } else {
						alert('No results found');
					  }
					} else {
					  alert('Geocoder failed due to: ' + status);
					}});
				}
			

			function error(msg) {
			  var s = document.querySelector('#status');
			  s.innerHTML = typeof msg == 'string' ? msg : "failed";
			  s.className = 'fail';
			  
			  // console.log(arguments);
			}

			if (navigator.geolocation) {
			  navigator.geolocation.getCurrentPosition(success, error);
			} else {
			  error('not supported');
			}
			
		
			
			
			function geocoding(){
				var st = document.getElementById('st').value;
				var city = document.getElementById('city').value;
				var code = document.getElementById('code').value;
				var country = document.getElementById('country').value;
				var address = st+ " " + city + " " + code + " " + country;
				var geocoder = new google.maps.Geocoder();
				var myOptions = {
							zoom: 8,
						  };
				var map = new google.maps.Map(document.getElementById("mapcanvas"), myOptions);
				geocoder.geocode( { 'address': address}, function(results, status) {
					if (status == google.maps.GeocoderStatus.OK) {
					  alert(results[0].geometry.location);
					  map.setCenter(results[0].geometry.location);
					  var marker = new google.maps.Marker({
						  map: map,
						  position: results[0].geometry.location
					  });
				
					} else {
					  alert('Geocode was not successful for the following reason: ' + status);
					}
				  });
				}

