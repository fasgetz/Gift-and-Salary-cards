import { createApp } from 'vue';

const vueApp = createApp({
    data() {
        return {
            isEnabledOfferta: false,
            isEnabledOffertaUkassa: false,
            sumPay: 1000,
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
    }
}).mount('#app');