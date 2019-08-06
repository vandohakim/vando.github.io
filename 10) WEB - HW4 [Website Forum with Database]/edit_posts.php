<?php
// include database connection file
include_once("connect.php");
$con=mysqli_connect("localhost","root","","forum");
// Check if form is submitted for user update, then redirect to homepage after update
if(isset($_POST['update']))
{   
    $id = $_POST['id'];

    $post_content=$_POST['post_content'];
    $post_date=$_POST['post_date'];

    // update user data
    $result = mysqli_query($con, "UPDATE posts SET post_content='$post_content',post_date=NOW() WHERE post_id=$id");
    // Redirect to homepage to display updated user in list
    if($result){header("Location:javascript://history.go(-1)");}
	echo 'Your reply has been saved, check out <a href="topic.php?id=' . htmlentities($_GET['id']) . '">the topic</a>.';
}
?>
<?php
// Display selected user data based on id
// Getting id from url
$id = $_GET['id'];
$post_content = mysqli_query($con, "SELECT * FROM posts WHERE post_id=$id");
$row = mysqli_fetch_array($post_content);
// Fetech user data based on id
?>
<html>
<head>  
    <title>Edit COMMENT</title>
</head>

<body>
<?php include 'header.php';?>
    <br/><br/>

    <form name="update_user" method="post" action="edit_posts.php">
        <table border="0">
            <tr> 
                <td>Your Comment</td>
                <td><input type="text" name="post_content" value="<?php echo $row['post_content'];?>"></td>
            </tr>
                <td><input type="hidden" name="id" value=<?php echo $_GET['id'];?>></td>
                <td><input type="submit" name="update" value="Update Comment"></td>
            </tr>
        </table>
    </form>
<?php include 'footer.php';?>
</body>
</html>
