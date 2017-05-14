<!DOCTYPE html>
<html>
<head>
     <?php 
	 $title = "Inregistrare";
	 ?>
	<meta charset="utf-8">
<title><?=$title?></title>
<link href="css/style.css" rel="stylesheet" type="text/css">
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
		<?php
		$connect = mysql_connect('localhost','root','') or die(mysql_error());
		mysql_select_db('midpsbase');
		
	    if(isset($_POST['submit'])) {
			$username = $_POST['username'];
			$login = $_POST['login'];
			$password = $_POST['password'];
			$r_password = $_POST['r_password'];
				$password = md5($password);
				$query = mysql_query("INSERT INTO users VALUES('', '$username', '$login', '$password')") or die(mysql_error());
			
			
				
		}
		
		?>
		<form method="post" action="reg.php">
		<input type="text" name="username" placeholder="| Username" required/> <br>
		<input type="text" name="login" placeholder="| Login" required/> <br>
		<input type="password" name="password" placeholder="| Password" required /> <br>
		<input type="password" name="r_password " placeholder="| Repeat Password" required /> <br>
		<input type="submit" name="submit" value="Inregistrare" />
		</form>
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
