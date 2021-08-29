import { createApp } from 'vue';
//import formcomponent from './formcomponent.vue'

//const vueApp = createApp({
//    components: {
//        formcomponent
//    }
//}).mount('#app');


const vueApp = createApp({
    data() {
        return {
            isEnabledOfferta: false,
            isEnabledOffertaUkassa: false,

            cardChecked: false,

            sumPay: 5000,
            procent: 0 // Процент комиссии нашего сервиса
        }
    },
    mounted() {
        this.procent = 12
    },
    computed: {
        // геттер вычисляемого значения получения процента
        GetProcent: function () {
            // `this` указывает на экземпляр vm
            return this.sumPay + (this.sumPay / 100 * this.procent)
        }
    },
    methods: {
        checkCard: function () {
            event.preventDefault();

            this.cardChecked = !this.cardChecked
        }
    }
}).mount('#app');