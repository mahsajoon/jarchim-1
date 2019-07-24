String.prototype.padLeft = function (l, c) { return Array(l - this.length + 1).join(c || " ") + this };

Date.prototype.addDays = function (days) {
 var dat = new Date(this.valueOf());
 dat.setDate(dat.getDate() + days);
 return dat;
}
