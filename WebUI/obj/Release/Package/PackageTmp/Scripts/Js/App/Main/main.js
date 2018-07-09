//This is main global javascript file
// 20151016 - by smeric
// Convert datetime object to specific format
function convertJSONDateToMVC(date, onlyDate) {
    var re = /-?\d+/;
    var m = re.exec(date);
    if (onlyDate) return new Date(parseInt(m[0]));
    return ConvertDatetime(new Date(parseInt(m[0])));
}
function ConvertDatetime(date,onlyDate) {
    var day = date.getDate();       // yields day
    var month = date.getMonth() + 1;  // yields month
    var year = date.getFullYear();  // yields year
    var hour = date.getHours();     // yields hours
    var minute = date.getMinutes(); // yields minutes
    var second = date.getSeconds(); // yields seconds
    if (onlyDate) return (day.length < 2 ? "0" + day : day) + "/" + (month.length < 2 ? "0" + month : month) + "/" + year;
    var time = day + "/" + month + "/" + year + " " + hour + ':' + minute + ':' + second;
    return time;
}
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
}