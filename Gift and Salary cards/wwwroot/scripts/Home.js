"use strict";
/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
(self["webpackChunkmyapplication"] = self["webpackChunkmyapplication"] || []).push([["Home"],{

/***/ "./scripts/Home/main.js":
/*!******************************!*\
  !*** ./scripts/Home/main.js ***!
  \******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ \"./node_modules/vue/dist/vue.esm-bundler.js\");\n\nconst vueApp = (0,vue__WEBPACK_IMPORTED_MODULE_0__.createApp)({\n  data() {\n    return {\n      currency: 5000\n    };\n  },\n\n  computed: {\n    currencyProcent: function () {\n      // `this` указывает на экземпляр vm\n      return this.currency + this.currency / 100 * 12;\n    }\n  }\n}).mount('#calculator');\n\n//# sourceURL=webpack://myapplication/./scripts/Home/main.js?");

/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["chunk-vendors"], () => (__webpack_exec__("./scripts/Home/main.js")));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);