<?php

require_once("config.php");

if(isset($_POST['register'])){

    // filter data yang diinputkan
    $name = filter_input(INPUT_POST, 'name', FILTER_SANITIZE_STRING);
    $username = filter_input(INPUT_POST, 'username', FILTER_SANITIZE_STRING);
    // enkripsi password
    $password = password_hash($_POST["password"], PASSWORD_DEFAULT);
    $email = filter_input(INPUT_POST, 'email', FILTER_VALIDATE_EMAIL);
	$birthday = filter_input(INPUT_POST, 'birthday', FILTER_SANITIZE_STRING);
	$phone = filter_input(INPUT_POST, 'phone', FILTER_SANITIZE_NUMBER_INT);
	$gender = filter_input(INPUT_POST, 'gender', FILTER_SANITIZE_STRING);
	$occupation = filter_input(INPUT_POST, 'occupation', FILTER_SANITIZE_STRING);
	$favcolor = filter_input(INPUT_POST, 'favcolor', FILTER_SANITIZE_STRING);

    // menyiapkan query
    $sql = "INSERT INTO users (name, username, password, email, birthday, phone, gender, occupation, favcolor) 
            VALUES (:name, :username, :password, :email, :birthday, :phone, :gender, :occupation, :favcolor)";
    $stmt = $db->prepare($sql);

    // bind parameter ke query
    $params = array(
        ":name" => $name,
        ":username" => $username,
        ":email" => $email,
		":password" => $password,
		":birthday" => $birthday,
		":phone" => $phone,
		":gender" => $gender,
		":occupation" => $occupation,
		":favcolor" => $favcolor        
    );

    // eksekusi query untuk menyimpan ke database
    $saved = $stmt->execute($params);

    // jika query simpan berhasil, maka user sudah terdaftar
    // maka alihkan ke halaman login
    if($saved) header("Location: login.php");
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Register yourself!</title>

    <link rel="stylesheet" href="css/bootstrap.min.css" />
</head>
<body class="bg-light">

<div class="container mt-5">
    <div class="row">
        <div class="col-md-6">

        <p>&larr; <a href="index.php">Home</a>

        <h4>Let's join with others...</h4>
        <p>Already have an account? <a href="login.php">Login here</a></p>

        <form action="" method="POST">

            <div class="form-group">
                <label for="name">Full Name</label>
                <input class="form-control" type="text" name="name" placeholder="Your name" required />
            </div>

            <div class="form-group">
                <label for="username">Username</label>
                <input class="form-control" type="text" name="username" placeholder="Username" required />
            </div>

            <div class="form-group">
                <label for="email">Email</label>
                <input class="form-control" type="email" name="email" placeholder="Email Address" required />
            </div>

            <div class="form-group">
                <label for="password">Password</label>
                <input class="form-control" type="password" name="password" placeholder="Password" required />
            </div>
			
            <div class="form-group">
                <label for="birthday">Birthday</label>
                <input class="form-control" type="date" name="birthday" placeholder="Birthday" required />
            </div>
			
			<div class="form-group">
                <label for="phone">Phone</label>
                <input class="form-control" type="number" name="phone" placeholder="Phone" required />
            </div>
			
            <div class="form-group">
                <label for="gender">Gender:</label>
				<div class="form-control">
				<input type="radio" name="gender" value="Male" required /> Male
				<input type="radio" name="gender" value="Female" required /> Female
				<input type="radio" name="gender" value="Other" required /> Other
				</div>
            </div>			

            <div class="form-group">
                <label for="occupation">Occupation:</label>
				<div class="form-control">
					<input type="checkbox" name="occupation" value="Teacher" /> Teacher
					<input type="checkbox" name="occupation" value="Student" /> Student
					<input type="checkbox" name="occupation" value="Other" /> Other
				</div>
            </div>
			
            <div class="form-group">
                <label for="favcolor">Favorite Color</label>
                <input type="color" name="favcolor" required />
            </div>			
			
            <input type="submit" class="btn btn-success btn-block" name="register" value="Daftar" />

        </form>
            
        </div>

        <div class="col-md-6">
            <img class="img img-responsive" src="img/connect.png" />
        </div>

    </div>
</div>

</body>
</html>