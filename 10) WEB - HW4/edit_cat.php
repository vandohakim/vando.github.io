<?php
// include database connection file
include_once("connect.php");
$con=mysqli_connect("localhost","root","","forum");
// Check if form is submitted for user update, then redirect to homepage after update
if(isset($_POST['update']))
{   
    $id = $_POST['id'];

    $cat_name=$_POST['cat_name'];
    $cat_description=$_POST['cat_description'];

    // update user data
    $result = mysqli_query($con, "UPDATE categories SET cat_name='$cat_name',cat_description='$cat_description',cat_date=NOW() WHERE cat_id=$id");

    // Redirect to homepage to display updated user in list
    header("Location: index.php");
}
?>
<?php
// Display selected user data based on id
// Getting id from url
$id = $_GET['id'];
$cat_name = mysqli_query($con, "SELECT * FROM categories WHERE cat_id=$id");
$row = mysqli_fetch_array($cat_name);
// Fetech user data based on id
?>
<html>
<head>  
    <title>Edit CATEGORIES</title>
</head>

<body>
<?php include 'header.php';?>
    <br/><br/>

    <form name="update_user" method="post" action="edit_cat.php">
        <table border="0">
            <tr> 
                <td>Category Name</td>
                <td><input type="text" name="cat_name" value="<?php echo $row['cat_name'];?>"></td>
            </tr>
			<tr> 
                <td>Category Description</td>
                <td><input type="text" name="cat_description" value="<?php echo $row['cat_description'];?>"></td>
            </tr>
                <td><input type="hidden" name="id" value=<?php echo $_GET['id'];?>></td>
                <td><input type="submit" name="update" value="Update Category"></td>
            </tr>
        </table>
    </form>
<?php include 'footer.php';?>
</body>
</html>
