<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<?php include ("menu.php") ?>
<table>
    <form method="post">
        <tr>
            <td>Hold navn:</td>
            <td><input type="text" name="holdnavn" placeholder="Holdnavn"></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" name="submit" value="Opret Hold" style="float:right;"></td>
        </tr>
    </form>
</table>

<?php
require ('Function/doSomethingFunction.php');
if(isset($_POST['submit'])){
    doSomethingFunction("http://mock3semprepwcfrest.azurewebsites.net/service1.svc/catch/");
}
?>
</body>
</html>