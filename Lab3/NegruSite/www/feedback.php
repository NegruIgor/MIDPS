<!DOCTYPE html>
<html>
<head>

     <?php 
	 $title = "Feedback";
	 ?>
	 
	 <meta charset="utf-8">
<title><?=$title?></title>
<link href="css/style.css" rel="stylesheet" type="text/css">

	 <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>
	 <script>
	   $(document).ready (function() {
	   	$("#done").click (function() {
	   		$('#messageShow').hide ();
	   		var name = $("#name").val();
	   		var email = $("#email").val();
	   		var subject = $("#subject").val();
	   		var message = $("#message").val();
	   		var fail = "";
	   		if (name.length < 3 ) fail = " Numele nu mai scrut de 3 simboale";
	   		else if (email.split('@').length - 1 == 0 || email.split('.').length - 1 == 0)
	   			fail ="Ai introdus email gresit";
	   		else if (subject.length < 5)
	   			fail = "Tema mai mica de 5 simboale";
	   		else if (message.length < 20)
	   			fail = "Mesajul mai scrut de 20 simboale";
	   		if (fail != ""){

	   			$('#messageShow').html (fail + "<div class='clear'><br></div>");
	   			$('#messageShow').show ();
	   			return false;
	   		 }
	   		 $.ajax ({
	   		 	url : '/ajax/feedback.php',
	   		 	type: 'POST',
	   		 	cache: false,
	   		 	data: {'name': name, 'email': email, 'subject':subject, 'message': message},
	   		 	dataType: 'html',
	   		 	success: function (data) {
	   		 		if(data == 'Mesajul trimis'){
	   		 			$('#messageShow').html (data + "<div class='clear'><br></div>");
	   			        $('#messageShow').show ();
	   		 		}
	   		 	}

	   		 });
	   	});
      
	   });
	 
	 </script>
</head>
<body>
     <header>
	    <div id="logo">
        <a href="/" title="Pagina principala"> <span>U</span>nreal Engine</a>
		</div>
		<div id="menuHead">
		<a href="/about.php">
		     <div style="margin-right: 5%">Despre noi</div> 
		</a>
	   <a href="/feedback.php">
		<div>Feedback</div>
		</a> 
		</div>
		<div id="regAuth">
		<a href="/reg.php">Inregistrare</a> | <a href="/auth.php">Autorizare </a>
		</div>
	 </header>
	 <div id="wrapper">
	    <div id="leftCol">
		
		<input type="text" placeholder="Nume" id="name" name="name"><br>
	    <input type="text" placeholder="Email" id="email" name="email"><br>
		<input type="text" placeholder="Tema mesajului" id="subjesct" name="subject"><br>
		<textarea name="message" id="message" placeholder="Introdu textul"></textarea><br>
		<div id="messageShow"></div>
		<input type="button" name="done" id="done" value="Trimite"><br>
		</div>
		<div id="rightCol">
		   <div class="banner">
		   <img src="/img/banners/1.jpg" alt="Banner 1" title="Banner 1">
		   </div>
		   <div class="banner">
		   <img src="/img/banners/2.jpg" alt="Banner 2" title="Banner 2">
		   </div>
		   <div class="banner">
		   <img src="/img/banners/3.jpg" alt="Banner 3" title="Banner 3">
		   </div>
		   <div class="banner">
		   <img src="/img/banners/4.jpg" alt="Banner 4" title="Banner 4">
		   </div>
		</div>
	 </div>
	 
	 <footer>
	       <div id="social">
		   <a href="https://www.facebook.com" title="Facebook" target="_blank">
		   <img src="/img/facebook.png" alt="Facebook" title="Facebook"> </a>
		   <a href="https://github.com" title="GitHub" target="_blank">
		   <img src="/img/github.png" alt="GitHub" title="GitHub"> </a>
		   </div>
		   
		   <div id="rights">
		         All rights reserved &copy; <?php echo date ('Y')?>
		    </div>
	 </footer>
</body>
</html>
