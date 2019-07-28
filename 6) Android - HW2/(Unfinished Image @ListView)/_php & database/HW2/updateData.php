<?php

	if($_SERVER['REQUEST_METHOD']=='POST'){
		//MEndapatkan Nilai Dari Variable
		$id = $_POST['id'];
		$name = $_POST['name'];
		$age = $_POST['age'];
		$weight = $_POST['weight'];
		$height = $_POST['height'];
		$gender = $_POST['gender'];
		$bmr = $_POST['bmr'];
		$bmi = $_POST['bmi'];

		//import file koneksi database
		require_once('koneksi.php');

		//Membuat SQL Query
		$sql = "UPDATE tb_pegawai SET name = '$name', age = '$age', weight = '$weight', height = '$height', gender = '$gender', bmr = '$bmr', bmi = '$bmi' WHERE id = $id;";

		//Meng-update Database
		if(mysqli_query($con,$sql)){
			echo 'Update Data Success';
		}else{
			echo 'Fail to Update Data';
		}

		mysqli_close($con);
	}
?>
