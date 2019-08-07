<?php
//create_cat.php
include 'connect.php';
include 'header.php';
$con=mysqli_connect("localhost","root","","forum");

echo '<h2>Create a category</h2>';
if($_SESSION['signed_in'] == false)
{
	//the user is not an admin
	echo 'Sorry, you do not have sufficient rights to access this page.';
}
else
{
	//the user has admin rights
	if($_SERVER['REQUEST_METHOD'] != 'POST')
	{
		//the form hasn't been posted yet, display it
		echo '<form method="post" action="">
			Category name: <input type="text" name="cat_name" />
			Category description: <textarea name="cat_description" /></textarea>
			<input type="submit" value="Add category" />
		 </form>';
	}
	else
	{
		//the form has been posted, so save it
		$cat_name = mysqli_real_escape_string($con, $_POST['cat_name']);
		$cat_description = mysqli_real_escape_string($con, $_POST['cat_description']);
		$cat_by = $_SESSION['user_name'];
		
		$sql="INSERT INTO categories (cat_name, cat_description, cat_by, cat_date)
				VALUES ('$cat_name', '$cat_description', '$cat_by', NOW())";
		
		if(!mysqli_query($con,$sql))
		{
			//something went wrong, display the error
			echo 'Error' . mysql_error($con);
		}
		else
		{
			echo 'New category successfully added.';
		}
	}
}
include 'footer.php';
?>