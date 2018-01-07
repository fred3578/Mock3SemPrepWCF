<?php
/**
 * Created by PhpStorm.
 * User: FrederikBlem
 * Date: 18/12/2017
 * Time: 23.18
 */

function getOneCatchFunction()
{
    $getcatchuri = "http://mock3semprepwcfrest.azurewebsites.net/service1.svc/catch/";
    $catchcontent = file_get_contents($getcatchuri);
    $decodedCatchContent = json_decode($catchcontent);
    return $decodedCatchContent;
    print_r($_SERVER['REQUEST_URI']);
}

?>

</body>
</html>