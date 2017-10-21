/// <reference path='src/index.d.ts'/>
/// <reference path='src/IStatic.d.ts'/>
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var jQuery = require("jquery/dist/jquery");
exports.default = jQuery;
function initJQuery(window) {
    return jQuery(window);
}
exports.initJQuery = initJQuery;
