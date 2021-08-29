"use strict";
/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
(self["webpackChunkmyapplication"] = self["webpackChunkmyapplication"] || []).push([["Payment"],{

/***/ "./scripts/Payment/main.js":
/*!*********************************!*\
  !*** ./scripts/Payment/main.js ***!
  \*********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ \"./node_modules/vue/dist/vue.esm-bundler.js\");\n //import formcomponent from './formcomponent.vue'\n//const vueApp = createApp({\n//    components: {\n//        formcomponent\n//    }\n//}).mount('#app');\n\nconst vueApp = (0,vue__WEBPACK_IMPORTED_MODULE_0__.createApp)({\n  data() {\n    return {\n      isEnabledOfferta: false,\n      isEnabledOffertaUkassa: false,\n      cardChecked: false,\n      sumPay: 5000,\n      procent: 0 // Процент комиссии нашего сервиса\n\n    };\n  },\n\n  mounted() {\n    this.procent = 12;\n  },\n\n  computed: {\n    // геттер вычисляемого значения получения процента\n    GetProcent: function () {\n      // `this` указывает на экземпляр vm\n      return this.sumPay + this.sumPay / 100 * this.procent;\n    }\n  },\n  methods: {\n    checkCard: function () {\n      event.preventDefault();\n      this.cardChecked = !this.cardChecked;\n    }\n  }\n}).mount('#app');\n\n//# sourceURL=webpack://myapplication/./scripts/Payment/main.js?");

/***/ })

},
/******/ __webpack_require__ => { // webpackRuntimeModules
/******/ var __webpack_exec__ = (moduleId) => (__webpack_require__(__webpack_require__.s = moduleId))
/******/ __webpack_require__.O(0, ["chunk-vendors"], () => (__webpack_exec__("./scripts/Payment/main.js")));
/******/ var __webpack_exports__ = __webpack_require__.O();
/******/ }
]);