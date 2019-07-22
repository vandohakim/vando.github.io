<?php require_once("auth.php"); ?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Member Login & Registration</title>
	<link rel="stylesheet" href="font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
	
		<style type="text/css">
		body {
			font-size: 15px;
			color: #343d44;
			font-family: "segoe-ui", "open-sans", tahoma, arial;
			padding: 0;
			margin: 0;
		}
		table {
			margin: auto;
			font-family: "Lucida Sans Unicode", "Lucida Grande", "Segoe Ui";
			font-size: 12px;
		}

		h1 {
			margin: 25px auto 0;
			text-align: center;
			text-transform: uppercase;
			font-size: 17px;
		}

		table td {
			transition: all .5s;
		}
		
		/* Table */
		.data-table {
			border-collapse: collapse;
			font-size: 14px;
			min-width: 537px;
		}

		.data-table th, 
		.data-table td {
			border: 1px solid #e1edff;
			padding: 7px 17px;
		}
		.data-table caption {
			margin: 7px;
		}

		/* Table Header */
		.data-table thead th {
			background-color: #508abb;
			color: #FFFFFF;
			border-color: #6ea1cc !important;
			text-transform: uppercase;
		}

		/* Table Body */
		.data-table tbody td {
			color: #353535;
		}
		.data-table tbody td:first-child,
		.data-table tbody td:nth-child(4),
		.data-table tbody td:last-child {
			text-align: left;
		}

		.data-table tbody tr:nth-child(odd) td {
			background-color: #f4fbff;
		}
		.data-table tbody tr:hover td {
			background-color: #ffffa2;
			border-color: #ffff0f;
		}

		/* Table Footer */
		.data-table tfoot th {
			background-color: #e5f5ff;
			text-align: right;
		}
		.data-table tfoot th:first-child {
			text-align: left;
		}
		.data-table tbody td:empty
		{
			background-color: #ffcccc;
		}
		</style>
</head>
<body class="bg-light">

<div class="container mt-5">
<h3><font color = "<?php echo $_SESSION["user"]["favcolor"] ?>">Member Info</h3>
    <div class="row">
        <div class="col-md-4">

            <div class="card">
                <div class="card-body text-center">

                    <img class="img img-responsive rounded-circle mb-3" width="160" src="img/<?php echo $_SESSION['user']['photo'] ?>" />
	
                    <h3><?php echo $_SESSION["user"]["name"] ?></h3>

					<div class="card-body text-left" class="list-group">
					  <a class="list-group-item"><i class="fa fa-envelope fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["email"] ?></a>
					  <a class="list-group-item"><i class="fa fa-birthday-cake fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["birthday"] ?></a>
					  <a class="list-group-item"><i class="fa fa-user-md fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["occupation"] ?></a>
					  <a class="list-group-item"><i class="fa fa-venus-mars fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["gender"] ?></a>
					  <a class="list-group-item"><i class="fa fa-tint fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["favcolor"] ?></a>
					  <a class="list-group-item"><i class="fa fa-phone fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["phone"] ?></a>
					  <a class="list-group-item"><i class="fa fa-history fa-fw" aria-hidden="true"></i>&nbsp; <?php echo $_SESSION["user"]["timestamp"] ?></a>
					</font></div>
                    <p><a href="logout.php">Logout</a></p>
                </div>
            </div>

            
        </div>

        <div class="col-md-8">
		<h3>Member List</h3>
		<div class="card mb-3">	
			<table class="data-table">
			  <thead>
				<tr>
				  <td align="center"><i class="fa fa-user fa-fw" aria-hidden="true"></i></td>
				  <td align="center"><i class="fa fa-envelope fa-fw" aria-hidden="true"></i></td>
				  <td align="center"><i class="fa fa-user-md fa-fw" aria-hidden="true"></i></td>
				  <td align="center"><i class="fa fa-venus-mars fa-fw" aria-hidden="true"></i></td>
				  <td align="center"><i class="fa fa-history fa-fw" aria-hidden="true"></i></td>
				</tr>
			  </thead>
			  <tbody>
				<tr>
				<?php
					$db_host = 'localhost'; // Nama Server
					$db_user = 'root'; // User Server
					$db_pass = ''; // Password Server
					$db_name = 'pesbuk'; // Nama Database

					$conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
					if (!$conn) {die ('Gagal terhubung dengan MySQL: ' . mysqli_connect_error());}

					$sql = 'SELECT * 
							FROM users';
					$query = mysqli_query($conn, $sql);
					if (!$query) {die ('SQL Error: ' . mysqli_error($conn));}
				?>
		<?php 
		while($data = mysqli_fetch_array($query)){
		?>
		<tr>
			<td><?php echo $data['username']; ?></td>
			<td><?php echo $data['email']; ?></td>
			<td><?php echo $data['occupation']; ?></td>
			<td><?php echo $data['gender']; ?></td>
			<td><?php echo $data['timestamp']; ?></td>
		</tr>
		<?php } ?>
			  </tbody>
			</table>
		</div></br>

		<h3>Upload & Download File</h3>
		<div class="card mb-8">	
			<form class="form-inline" method="POST" action="upload.php" enctype="multipart/form-data">
			 <input class="form-control" type="file" name="upload"/>
			 <button type="submit" class="btn btn-success form-control" name="submit"><span class="glyphicon glyphicon-upload"></span> Upload</button>
			</form>
			<br/>			
			<div class="form-group">
			  <table id="example" class="display responsive nowrap" style="width:100%">
				<thead>
				  <tr>  
					<th>No</th>
					<th>File Name</th>
					<th>Size</th>
					<th>Directory</th>
					<th>Time</th>					
					<th>Action</th>
				  </tr>
				</thead>
				<tbody class="alert-success">
				  <?php
				  require 'configdb.php';
				  $row = $conn->query("SELECT * FROM `file`") or die(mysqli_error());
				  while($fetch = $row->fetch_array()){
				  ?>
				  <tr>
					<?php 
					$name = explode('/', $fetch['file']);
					?>
					<td><?php echo $fetch['file_id']?></td>
					<td><?php echo $fetch['name']?></td>
					<td><?php echo $fetch['size']?></td>
					<td><?php echo $fetch['file']?></td>
					<td><?php echo $fetch['timestamp']?></td>
					<td><a href="download.php?file=<?php echo $name[1]?>" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Download</a></td>
				  </tr>
				  <?php
					}
					?>
			  </tbody>
			 </table>
			</div>
		</div>
		</div>
    </div>
</div>
</body>
</html>