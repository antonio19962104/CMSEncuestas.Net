<html>
<head>
  <style type="text/css">
    table input {
      width: 30px;
      text-align: center;
    }
  </style>
  <script src="jquery-3.4.1.min.js" type="text/javascript"></script>
  <script src="html2canvas.js" type="text/javascript"></script>
  <script src="http://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.3/jspdf.min.js"></script>

  <script type="text/javascript">
    async function exportar(){
        var docReporte = new jsPDF("landscape");
         var data = await docReporte.addHTML($('#exportar')[0], 0, 0, { /* options */ }
            , function () {
                docReporte.save();
            });
         console.log(data);
    }
  </script>
</head>
<body>
<div hidden="">
    <table>
    <tbody>
        <tr>
            <td><input type="text" id="pos_0_0" disabled /></td>     <td><input type="text" id="pos_1_0" disabled /></td>     <td><input type="text" id="pos_2_0" disabled /></td>
        </tr>
        <tr>
            <td><input type="text" id="pos_0_1" disabled /></td>     <td><input type="text" id="pos_1_1" disabled /></td>     <td><input type="text" id="pos_2_1" disabled /></td>
        </tr>
        <tr>
            <td><input type="text" id="pos_0_2" disabled /></td>     <td><input type="text" id="pos_1_2" disabled /></td>     <td><input type="text" id="pos_2_2" disabled /></td>
        </tr>
    </tbody>
</table>
<input type="button" onclick="cat()" value="de" />
</div>
<div id="exportar" style="background-color: #fff;">
    <p>Hello</p>
</div>
<input type="button" name="" onclick="exportar()" value="exportar">
</body>
</html>