<!DOCTYPE html>
<html>
<head>
     <?php 
	 $mysqli = false;
	 function connectDB () {
		 global $mysqli;
		 $mysqli = new mysqli("localhost", "root", "", "midpsbase");
		 $mysqli -> query("SET NAMES 'uft-8'");
	 }
	 function closeDB () {
		 global $mysqli;
		 $mysqli -> close ();
	 }
	 
	 function getNews ($limit, $id) {
		 global $mysqli;
		 connectDB();
		 if($id)
			$where = "WHERE `id` =".$id;
		 $result = $mysqli->query("SELECT * FROM `news` $where ORDER BY `id` DESC LIMIT $limit");
		 closeDB();
		 if(!$id)
		    return resultToArray($result);
		else
			return $result->fetch_assoc();
	 }
	 
	 function resultToArray ($result) {
		 $array = array ();
		 while(($row = $result->fetch_assoc()) != false)
			 $array[] = $row;
		 return $array;
	 }
	 $news = getNews(1, $_GET["id"]);
	 $title = $news["title"];
	 
	 
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
			echo '<div class="bigArticle"><img src="/img/articles/'.$news["id"].'.jpg" alt="article '.$news[$i]["id"].'" title="article '.$news[$i]["id"].'">
	                          <h2>'.$news["title"].' </h2>
    <p>'.$news["full_text"].' </p>
		   </div>';
		?>
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





 