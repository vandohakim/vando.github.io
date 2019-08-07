<?php

 //Mendapatkan Nilai ID
 $id = $_GET['id'];

 //Import File Koneksi Database
 require_once('koneksi.php');

 //Membuat SQL Query
 $sql = "DELETE FROM tb_pegawai WHERE id=$id;";


 //Menghapus Nilai pada Database
 if(mysqli_query($con,$sql)){
 echo 'Delete Data Complete';
 }else{
 echo 'Failed to Delete Data';
 }

 mysqli_close($con);
 ?>
