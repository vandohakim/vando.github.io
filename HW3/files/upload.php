<?php
require_once 'configdb.php';

if(ISSET($_POST['submit'])){
	if($_FILES['upload']['name'] != "") {
		$file = $_FILES['upload'];
		
		$file_name = $file['name'];
		$ukuran = $file['size'];
		$file_temp = $file['tmp_name'];
		$name = explode('.', $file_name);
		$path = "files/".$file_name;
		
		$conn->query("INSERT INTO `file` VALUES('', '$name[0]', '$path', $ukuran)") or die(mysqli_error($conn));
		
		move_uploaded_file($file_temp, $path);
		header("location:timeline.php");
		
	}else{
		echo "<script>alert('Required Field!')</script>";
		echo "<script>window.location='index.php'</script>";
	}
}
?>

