<?php
require ('Function/getOneCatchFunction.php');
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Get One Catch Page</title>
</head>
<body>
<?php include ("menu.php"); ?>
<form method="get">
    <select name="Id">
        <option value="0">-- None --</option>
        <?php $catchdata[] = getOneCatchFunction(); ?>
        <?php foreach ($catchdata[0] as $item)
        {
            echo "<option value=".$item->Id. ">".$item->Id."</option>";
        } ?>
    </select>
    <input type="submit" value="vælg fangsts Id">
</form>
<?php
if(isset($_POST['submit']))
{
    $getOneCatchFunction = "http://mock3semprepwcfrest.azurewebsites.net/service1.svc/catch/" . $_GET['Id'];

    $content = file_get_contents($getresturi);

    $decodedContent = json_decode($content);
    print_r($_SERVER['REQUEST_URI']);


}
?>
<table>
    <tr>
        <td><input type="text" name="Id" class="form-control" value="<?php echo $decodedContent->Id?>"></td>
    </tr>
</table>
</body>
</html>