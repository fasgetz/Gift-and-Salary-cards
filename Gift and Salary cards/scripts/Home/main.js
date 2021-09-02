import { createApp } from 'vue';

const vueApp = createApp({
    data() {
        return { currency: 5000 }
    },
    computed: {
        currencyProcent: function () {
            // `this` указывает на экземпляр vm
            return (this.currency + (this.currency / 100 * 12))
        }
    }
}).mount('#calculator');