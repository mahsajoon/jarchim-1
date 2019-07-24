function fRandom(pMin, pMax) {

 return Math.floor(Math.random() * (pMax - pMin + 1)) + pMin;
}

function fGetCurrentUrl() {
 project = window.location.pathname.split('/');
 url = window.location.protocol + '//' + window.location.host + '/'
 return url;
}
function fIsEmptyValue(p) {
 if (p == undefined) return true;
 if (typeof (p) == 'function' || 
     typeof (p) == 'number' || 
     typeof (p) == 'boolean' || 
     Object.prototype.toString.call(p) === '[object Date]') return false;
 if (p == null || p.length === 0) return true;
 if (typeof (p) == "object") {
  var r = true;
  for (var f in val)
   r = false;
  return r;
 }
 return false;
}

