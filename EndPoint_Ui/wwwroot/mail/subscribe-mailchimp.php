<?php
// Mailchimp configuration
$mailchimpApiKey = "YOUR_MAILCHIMP_API_KEY";
$mailchimpListId = "YOUR_MAILCHIMP_LIST_ID";

// Mailchimp API endpoint
$mailchimpEndpoint = "https://<dc>.api.mailchimp.com/3.0/lists/$mailchimpListId/members";

// Replace <dc> with your Mailchimp datacenter (e.g., us1, us2, etc.)
// Your datacenter is the prefix in your API key after the dash.
$mailchimpEndpoint = str_replace("<dc>", explode("-", $mailchimpApiKey)[1], $mailchimpEndpoint);

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

// Prepare data for Mailchimp API
$data = [
    "email_address" => $email,
    "status" => "subscribed",
];

$jsonData = json_encode($data);

// Initialize cURL session
$ch = curl_init($mailchimpEndpoint);
curl_setopt($ch, CURLOPT_HTTPHEADER, [
    "Content-Type: application/json",
    "Authorization: apikey $mailchimpApiKey",
]);
curl_setopt($ch, CURLOPT_POST, true);
curl_setopt($ch, CURLOPT_POSTFIELDS, $jsonData);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

// Execute cURL session
$response = curl_exec($ch);
$httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
curl_close($ch);

// Process response
if ($httpCode === 200) {
    echo json_encode(["status" => true]);
} else {
    $responseDecoded = json_decode($response, true);
    $errorMessage = isset($responseDecoded['detail']) ? $responseDecoded['detail'] : "api-error";
    echo json_encode(["status" => false, "msg" => $errorMessage]);
}
?>
