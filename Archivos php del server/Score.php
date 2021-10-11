<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$Nota=$_POST['Nota'];
$idStundetQualification=$_POST['idStundetQualification'];
$idTematic=$_POST['idTematic'];



// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}

  $sql = "SELECT EstudianteIdEstudiante,TemaIdTematica FROM estudiantetema WHERE EstudianteIdEstudiante='$idStundetQualification' AND TemaIdTematica='$idTematic'";

  $result = $conn->query($sql); 

    if ($result->num_rows > 0) {
     
      echo("truie");

      $sql1 = "UPDATE estudiantetema set Nota='$Nota' WHERE EstudianteIdEstudiante='$idStundetQualification' AND TemaIdTematica='$idTematic'"; 

      if ($conn->query($sql1) === TRUE) {
      echo "Actualizo nota";//docente inactivo

      } else {
       echo "Error: " . $sql . "<br>" . $conn->error;

      }
      




    }else {
 
      $sql2 = "INSERT INTO estudiantetema (EstudianteIdEstudiante,TemaIdTematica,Nota) VALUES  ('$idStundetQualification','$idTematic','$Nota')";
         if ($conn->query($sql2) === TRUE) {
         echo "New record created successfully";
        } else {
         echo "Error: " . $sql . "<br>" . $conn->error;
        }

     }


  

$conn->close();
?>