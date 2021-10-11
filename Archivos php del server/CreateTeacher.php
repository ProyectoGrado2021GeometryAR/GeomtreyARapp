<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario reciben mediante metodo post la informacion //enviada de la aplicacion
$createIdTeacher=$_POST['createIdTeacher'];
$createNamesTeacher=$_POST['createNamesTeacher'];
$createLastNamesTeacher=$_POST['createLastNamesTeacher'];
$createEmailTeacher=$_POST['createEmailTeacher'];
$createPasswordTeacher=$_POST['createPasswordTeacher'];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}


$sql = "SELECT EmailDocente, IdDocente FROM docente WHERE emailDocente = '".$createEmailTeacher."'";
$result = $conn->query($sql); 

$sql1 = "SELECT EmailDocente, IdDocente FROM docente WHERE IdDocente = '$createIdTeacher'";
$result1 = $conn->query($sql1); 

if ($result->num_rows > 0) {
  //tell user that that name is already taken
    echo"stop";
}else if ($result1->num_rows > 0){
    echo"stop";

} else {
//insert the user and passqord into the database
echo"creating user";

$sql2 = "INSERT INTO docente (idDocente, nombresDocente, apellidosDocente, emailDocente, contrasenaDocente,rango,Active) VALUES ('$createIdTeacher','".$createNamesTeacher."', '".$createLastNamesTeacher."', '".$createEmailTeacher."', '".$createPasswordTeacher."',1,1)";



if ($conn->query($sql2) === TRUE) {
  echo "New record created successfully";
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

}
$conn->close();
?>