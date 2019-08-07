<?php
//create_cat.php
include 'connect.php';
include 'header.php';
$con=mysqli_connect("localhost","root","","forum");

$topic_id = mysqli_real_escape_string($con, $_GET['id']);
$sql = "SELECT
			topics.topic_id,
			topics.topic_cat,
			topics.topic_subject,
			users.user_id,
			users.user_name
		FROM
			topics
		LEFT JOIN
			users
		ON
			topics.topic_by = users.user_id
		WHERE
			topics.topic_id = '$topic_id'";
			
			
$result = mysqli_query($con,$sql);

if(!$result)
{
	echo 'The topic could not be displayed, please try again later.';
}
else
{
	if(mysqli_num_rows($result) == 0)
	{
		echo 'This topic doesn&prime;t exist.';
	}
	else
	{
		while($row = mysqli_fetch_assoc($result))
		{
			//display post data
			if ($_SESSION['user_name'] == $row['user_name'])
			{
			echo '<table class="topic" border="1">
					<tr>
						<th colspan="2">' . $row['topic_subject'] . '</th>
						<th colspan="2"><h3><a href="edit_topics.php?id=' . $row['topic_id'] . '">Edit</a> or <a href="delete_topics.php?id=' . $row['topic_id'] . '">Delete</a><h3></td></th>
					</tr>';
			}
			else 
			{
			echo '<table class="topic" border="1">
					<tr>
						<th colspan="2">' . $row['topic_subject'] . '</th>
					</tr>';	
			}
			$post_topic = mysqli_real_escape_string($con, $_GET['id']);
			//fetch the posts from the database
			$posts_sql = "SELECT
						posts.post_id,
						posts.post_topic,
						posts.post_content,
						posts.post_date,
						posts.post_by,
						users.user_id,
						users.user_name
					FROM
						posts
					LEFT JOIN
						users
					ON
						posts.post_by = users.user_id
					WHERE
						posts.post_topic = '$post_topic'";
						
			$posts_result = mysqli_query($con,$posts_sql);
			
			if(!$posts_result)
			{
				echo '<tr><td>The posts could not be displayed, please try again later.</tr></td></table>';
			}
			else
			{
			
				while($posts_row = mysqli_fetch_assoc($posts_result))
				{
					if ($posts_row['user_name'] == $_SESSION['user_name'])
					{
					echo '<tr class="topic-post">
						<td class="user-post">' . $posts_row['user_name'] . '<br/>' . date('d-m-Y H:i', strtotime($posts_row['post_date'])) . '</td>
						<td class="post-content">' . htmlentities(stripslashes($posts_row['post_content'])) . '</td>
						<td class="post-content"><h3><a href="edit_posts.php?id=' . $posts_row['post_id'] . '">Edit</a> or <a href="delete_posts.php?id=' . $posts_row['post_id'] . '"">Delete</a><h3></td>
						</tr>';
					}	
					else
					{
					echo '<tr class="topic-post">
						<td class="user-post">' . $posts_row['user_name'] . '<br/>' . date('d-m-Y H:i', strtotime($posts_row['post_date'])) . '</td>
						<td class="post-content">' . htmlentities(stripslashes($posts_row['post_content'])) . '</td>
						</tr>';
					}
				}
			}
			
			if(!$_SESSION['signed_in'])
			{
				echo '<tr><td colspan=2>You must be <a href="signin.php">signed in</a> to reply. You can also <a href="signup.php">sign up</a> for an account.';
			}
			else
			{
				//show reply box
				echo '<tr><td colspan="2"><h2>Reply:</h2><br />
					<form method="post" action="reply.php?id=' . $row['topic_id'] . '">
						<textarea name="reply-content"></textarea><br /><br />
						<input type="submit" value="Submit reply" />
					</form></td></tr>';
			}
			
			//finish the table
			echo '</table>';
		}
	}
}

include 'footer.php';
?>