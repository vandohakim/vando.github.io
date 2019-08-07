<?php
//create_cat.php
include 'connect.php';
include 'header.php';
$con=mysqli_connect("localhost","root","","forum");
 
if($_SERVER['REQUEST_METHOD'] != 'POST')
{
	//someone is calling the file directly, which we don't want
	echo 'This file cannot be called directly.';
}
else
{
    //check for sign in status
    if(!$_SESSION['signed_in'])
    {
        echo 'You must be signed in to post a reply.';
    }
    else
    {
		$post_content = mysqli_real_escape_string($con, $_POST['reply-content']);
		$post_topic = mysqli_real_escape_string($con, $_GET['id']);
		$post_by = mysqli_real_escape_string($con, $_SESSION['user_id']);
        //a real user posted a real reply
        $sql = "INSERT INTO 
                    posts(post_content,
                          post_date,
                          post_topic,
                          post_by) 
                VALUES ('$post_content',
                        NOW(),
                        '$post_topic',
                        '$post_by')";
                         
        $result = mysqli_query($con,$sql);
                         
        if(!$result)
        {
			die('Error: ' . mysqli_error($con));
            echo 'Your reply has not been saved, please try again later.';
        }
        else
        {
            echo 'Your reply has been saved, check out <a href="topic.php?id=' . htmlentities($_GET['id']) . '">the topic</a>.';
        }
    }
}
 
include 'footer.php';
?>