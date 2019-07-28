<?php

	if($_SERVER['REQUEST_METHOD']=='POST'){

		//Mendapatkan Nilai Variable
		$name = $_POST['name'];
		$age = $_POST['age'];
		$weight = $_POST['weight'];
		$height = $_POST['height'];
		$gender = $_POST['gender'];
		$bmr = $_POST['bmr'];
		$bmi = $_POST['bmi'];
		
		//Pembuatan Syntax SQL
		$sql = "INSERT INTO tb_pegawai (name,age,weight,height,gender,bmr,bmi) VALUES ('$name','$age','$weight','$height','$gender','$bmr','$bmi')";

		//Import File Koneksi database
		require_once('koneksi.php');

		//Eksekusi Query database
		if(mysqli_query($con,$sql)){
			echo 'Add Data Success';
		}else{
			echo 'Fail to Add Data';
		}

		mysqli_close($con);
	}
?>
