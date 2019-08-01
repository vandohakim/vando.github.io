<?php
//create_cat.php
include 'connect.php';
include 'header.php';
$con=mysqli_connect("localhost","root","","forum");

$cat_id = mysqli_real_escape_string($con, $_GET['id']);
//first select the category based on $_GET['cat_id']
$sql = "SELECT
            cat_id,
            cat_name,
            cat_description
        FROM
            categories
        WHERE
            cat_id = '$cat_id'";
 
$result = mysqli_query($con,$sql);
 
if(!$result)
{
    echo 'The category could not be displayed, please try again later.' . mysqli_error($con);
}
else
{
    if(mysqli_num_rows($result) == 0)
    {
        echo 'This category does not exist.';
    }
    else
    {
        //display category data
        while($row = mysqli_fetch_assoc($result))
        {
            echo '<h2>Topics in ′' . $row['cat_name'] . '′ category</h2>';
        }
		$topic_cat = mysqli_real_escape_string($con, $_GET['id']); 
        //do a query for the topics
        $sql = "SELECT  
                    topics.topic_id,
                    topics.topic_subject,
                    topics.topic_date,
                    topics.topic_cat,
					topics.topic_by,
					users.user_id,
					users.user_name
                FROM
                    topics
				LEFT JOIN
					users
				ON
					topics.topic_by = users.user_id
                WHERE
                    topic_cat = '$topic_cat'";
         
        $result = mysqli_query($con,$sql);
         
        if(!$result)
        {
            echo 'The topics could not be displayed, please try again later.';
        }
        else
        {
            if(mysqli_num_rows($result) == 0)
            {
                echo 'There are no topics in this category yet.';
            }
            else
            {
                //prepare the table
                echo '<table border="1">
                      <tr>
                        <th>Topic</th>
                        <th>Created at</th>
						<th>Posted by</th>
                      </tr>'; 
                     
                while($row = mysqli_fetch_assoc($result))
                {               
                    echo '<tr>';
                        echo '<td class="leftpart">';
                            echo '<h3><a href="topic.php?id=' . $row['topic_id'] . '">' . $row['topic_subject'] . '</a><h3>';
                        echo '</td>';
                        echo '<td class="rightpart">';
                            echo date('d-m-Y', strtotime($row['topic_date']));
                        echo '</td>';
                        echo '<td class="leftpart">';
                            echo '<h3>' . $row['user_name'] . '<h3>';
                        echo '</td>';
                    echo '</tr>';
                }
            }
        }
    }
}
 
include 'footer.php';
?>