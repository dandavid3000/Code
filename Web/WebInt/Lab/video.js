function rotate(){
	var video1 = document.getElementById('video1');
	if (video1.style.transform == '')
		previousDegree='rotate(0deg)';
	else
		var previousDegree= video1.style.transform;
	var match1 =  previousDegree.match(/([0-9]+)/)[1];
	
	var newdegree= parseInt(match1)+30;

	
	var newstyle= 'rotate('+newdegree+'deg)';
	video1.style.transform=newstyle;
}


function mirrorVideo()
{
   	var context, rctxt, video;
	video = document.getElementsByTagName("video")[0];
	reflection = document.getElementById("reflection");
	rctxt = reflection.getContext("2d");

	var w = video.videoWidth;
	var h = video.videoHeight;
	//var h = 200;
	//var w = 350;
	
	reflection.width = w;
        reflection.height = h;
	rctxt.translate(0,h);
	rctxt.scale(1,-1);
	paintFrame();
	
	function paintFrame() {
	
	rctxt.drawImage(video, 0, 0, w , h);
	rctxt.fill();

	if (video.paused || video.ended) {
	  return;
	}
	
	setTimeout(function () {
	   paintFrame();
	}, 0);}
	
	video.play();
}



function hideControl(){
	var video = document.getElementById('video1')
	 if (video.hasAttribute("controls")) {
		video.removeAttribute("controls")} 
	else {
	video.setAttribute("controls","controls")}
	}
	
function takeSnapShoot(){
	var video = document.getElementById('video1');
	//Ve canvas ra
	var canvas = document.getElementById('canvas1');
	// Get a handle on the 2d context of the canvas element
	var context = canvas.getContext('2d');
	// Define some vars required later
	var w, h, ratio;
	//var w = video.videoWidth;
	//var h = video.videoHeight;
	var w = 150;
	var h = 100;
	canvas.width = w;
	canvas.height = h;
	
	context.fillRect(0, 0, w, h);
	// Grab the image from the video
	context.drawImage(video, 0, 0, w, h);


}


function playNewVideo(){

	var urlvideoValue=document.playVideo.txturlvideo.value;
	var video = document.getElementById('video1');
	var videosource = document.getElementById('videosrc');
//	alert(urlvideoValue);
	video.pause();
	//videosource.setAttribute("src", urlvideoValue);
	videosource.src=urlvideoValue;
	video.load();
	video.play();
	}

function jumpVideo()
{
     var jumpTime=document.playVideo.jumpnumber.value;
	 var video = document.getElementById('video1');
     var videosource = document.getElementById('videosrc');
	 var srcValue=videosource.src;
	 
	 video.pause();
	 video.currentTime=jumpTime;
	 
	 //srcValue=srcValue+'#t='+jumpTime;
	 // videosource.src=srcValue;
	 //alert(srcValue);
	 
	 
	 video.play();
}
