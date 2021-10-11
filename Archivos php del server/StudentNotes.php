<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$notesByDegree=$_POST['notesByDegree'];

$degre=$_POST['degree'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}

    if($degre=='4'){
        
             $sql = "SELECT IdEstudiante,NombresEstudiante, ApellidosEstudiante, GradoIdGrado, Nota, NombreTematica FROM estudiante, tema,estudiantetema WHERE IdEstudiante= EstudianteIdEstudiante AND TemaIdTematica = IdTematica AND GradoIdGrado=4 AND IdEstudiante='$notesByDegree'";
                    $result = $conn->query($sql); 

            if ($result->num_rows > 0) {
            // output data of each row

                 while($row = $result->fetch_assoc()) {
  
                  echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["NombreTematica"]."|".$row["Nota"]."|");
 
  
    
                 }

                echo("stop");
            }else{
                echo("stop");
            }
        
    } if($degre=='5'){
       
        
               $sql2 = "SELECT IdEstudiante,NombresEstudiante, ApellidosEstudiante, GradoIdGrado, Nota, NombreTematica FROM estudiante, tema,estudiantetema WHERE IdEstudiante= EstudianteIdEstudiante AND TemaIdTematica = IdTematica AND GradoIdGrado=5 AND IdEstudiante='$notesByDegree'";
                    $result = $conn->query($sql2); 

            if ($result->num_rows > 0) {
            // output data of each row

                 while($row = $result->fetch_assoc()) {
  
                  echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["NombreTematica"]."|".$row["Nota"]."|");
 
  
    
                 }
                  echo("stop");
            }else{
                echo("stop");
            }
    }else if($degre=='45'){
        
       $sql3 = "SELECT IdEstudiante,NombresEstudiante, ApellidosEstudiante, NombreTematica, Nota  FROM estudiante, tema,estudiantetema WHERE IdEstudiante= EstudianteIdEstudiante AND TemaIdTematica = IdTematica AND IdEstudiante='$notesByDegree'";
            $result = $conn->query($sql3); 

            if ($result->num_rows > 0) {
            // output data of each row

                 while($row = $result->fetch_assoc()) {
  
                  echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["NombreTematica"]."|".$row["Nota"]."|");
 
  
    
                 }   echo("stop");
            }else{
                echo("stop");
            }
    }


$conn->close();
?>