<?php
$servername = "localhost";
$username = "id17469917_proyectogar";
$password = "pN&x|8E=qkOyM?}@";
$dbname = "id17469917_projectdegree";
//variables del usuario
$searchStudentById=$_POST['searchStudentById'];
$degree=$_POST['degree'];
//


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error); 
}

    if ($degree==4){
        
        $sql ="SELECT IdEstudiante,GradoIdGrado,NombresEstudiante, ApellidosEstudiante ,EmailEstudiante,ContrasenaEstudiante,EstadoEstudiante FROM estudiante WHERE GradoIdGrado=4 AND IdEstudiante ='".$searchStudentById."'"; 
        $result = $conn->query($sql); 
            if ($result->num_rows > 0) {
             // output data of each row

             while($row = $result->fetch_assoc()) {
  
   
                      echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["EmailEstudiante"]."|".$row["ContrasenaEstudiante"]."|".$row["GradoIdGrado"]."|".$row["EstadoEstudiante"]."|");
     

    
                         }

                 echo("stop");
                } else {
           
                    echo("stop");
        
                }
        
        
    }else if($degree==5){
        
        $sql ="SELECT IdEstudiante,GradoIdGrado,NombresEstudiante, ApellidosEstudiante ,EmailEstudiante,ContrasenaEstudiante,EstadoEstudiante FROM estudiante WHERE GradoIdGrado=5 AND IdEstudiante ='".$searchStudentById."'"; 
        $result = $conn->query($sql); 
            if ($result->num_rows > 0) {
             // output data of each row

             while($row = $result->fetch_assoc()) {
  
   
                      echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["EmailEstudiante"]."|".$row["ContrasenaEstudiante"]."|".$row["GradoIdGrado"]."|".$row["EstadoEstudiante"]."|");
     

    
                         }

                 echo("stop");
                } else {
           
                    echo("stop");
        
                } 
        
        
        
    }else if($degree==45){
         $sql ="SELECT IdEstudiante,GradoIdGrado,NombresEstudiante, ApellidosEstudiante ,EmailEstudiante,ContrasenaEstudiante,EstadoEstudiante FROM estudiante WHERE IdEstudiante ='".$searchStudentById."'"; 
        $result = $conn->query($sql); 
            if ($result->num_rows > 0) {
             // output data of each row

             while($row = $result->fetch_assoc()) {
  
   
                      echo($row["IdEstudiante"]."|".$row["NombresEstudiante"]."|".$row["ApellidosEstudiante"]."|".$row["EmailEstudiante"]."|".$row["ContrasenaEstudiante"]."|".$row["GradoIdGrado"]."|".$row["EstadoEstudiante"]."|");
     

    
                         }

                 echo("stop");
                } else {
           
                    echo("stop");
        
                }
    }











$conn->close();
?>