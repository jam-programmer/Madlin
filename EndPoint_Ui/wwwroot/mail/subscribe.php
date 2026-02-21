<?php
// Database configuration
$host = "localhost";
$username = "root";
$password = "";
$dbname = "newsletter";

// Create connection
$conn = new mysqli($host, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die(json_encode(["status" => false, "msg" => "db-error"]));
}

// Create table if it doesn't exist
$tableQuery = "CREATE TABLE IF NOT EXISTS subscribers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) NOT NULL UNIQUE,
    subscribed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)";

if (!$conn->query($tableQuery)) {
    die(json_encode(["status" => false, "msg" => "table-creation-error"]));
}

// Retrieve and sanitize input
$email = filter_input(INPUT_POST, 'subscribeEmail', FILTER_SANITIZE_EMAIL);

if (!$email) {
    echo json_encode(["status" => false, "msg" => "email-required"]);
    exit;
}

if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    echo json_encode(["status" => false, "msg" => "email-err"]);
    exit;
}

// Check for duplicate email
$checkQuery = $conn->prepare("SELECT id FROM subscribers WHERE email = ?");
$checkQuery->bind_param("s", $email);
$checkQuery->execute();
$checkQuery->store_result();

if ($checkQuery->num_rows > 0) {
    echo json_encode(["status" => false, "msg" => "duplicate"]);
    exit;
}
$checkQuery->close();

// Insert new subscriber
$insertQuery = $conn->prepare("INSERT INTO subscribers (email) VALUES (?)");
$insertQuery->bind_param("s", $email);

if ($insertQuery->execute()) {
    echo json_encode(["status" => true]);
} else {
    echo json_encode(["status" => false, "msg" => "filewrite"]);
}

$insertQuery->close();
$conn->close();
?>
