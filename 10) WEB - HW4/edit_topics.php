<?php
// include database connection file
include_once("connect.php");
$con=mysqli_connect("localhost","root","","forum");
// Check if form is submitted for user update, then redirect to homepage after update
if(isset($_POST['update']))
{   
    $id = $_POST['id'];

    $topic_subject=$_POST['topic_subject'];
    $topic_date=$_POST['topic_date'];

    // update user data
    $result = mysqli_query($con, "UPDATE topics SET topic_subject='$topic_subject',topic_date=NOW() WHERE topic_id=$id");

    // Redirect to homepage to display updated user in list
    if($result){header("Location:javascript://history.go(-1)");}
	echo 'Your reply has been saved, check out <a href="topic.php?id=' . htmlentities($_GET['id']) . '">the topic</a>.';
}
?>
<?php
// Display selected user data based on id
// Getting id from url
$id = $_GET['id'];
$topic_subject = mysqli_query($con, "SELECT * FROM topics WHERE topic_id=$id");
$row = mysqli_fetch_array($topic_subject);
// Fetech user data based on id
?>
<html>
<head>  
    <title>Edit TOPICS</title>
</head>

<body>
<?php include 'header.php';?>
    <br/><br/>

    <form name="update_user" method="post" action="edit_topics.php">
        <table border="0">
            <tr> 
                <td>Topic Subject</td>
                <td><input type="text" name="topic_subject" value="<?php echo $row['topic_subject'];?>"></td>
            </tr>
                <td><input type="hidden" name="id" value=<?php echo $_GET['id'];?>></td>
                <td><input type="submit" name="update" value="Update"></td>
            </tr>
        </table>
    </form>
<?php include 'footer.php';?>
</body>
</html>
