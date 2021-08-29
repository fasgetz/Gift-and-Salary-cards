<template>
    <div class="container">
        <h3 class="text-center">Оплата онлайн</h3>
        <div class="payment-block__payment-form mt-3">
            <form id="app">
                <div v-if="selectedPaymentType != null && (selectedPaymentType.Id == 2 || selectedPaymentType.Id == 3)" class="form-group mt-3">
                    <div class="form-group">
                        <label>Выберите тип оплаты</label>
                        <select v-model="selectedPaymentType" class="form-control">
                            <option v-for="(item, index) in paymentsTypesItems" v-bind:key="item" v-bind:value="item">{{item.Name}} {{item.Procent}}%</option>
                        </select>
                        <div class="mt-1 text-center text-danger">
                            <span>Если вы уже вносили первоначальный взнос, то введите номер заказа, прописанный в договоре, при оплате вторичных и заключительных взносов!</span>
                        </div>
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlInput1">Введите номер заказа</label>
                        <input v-model.number="numberOrder" type="number" class="form-control" id="exampleFormControlInput1" placeholder="Номер заказа">
                    </div>
                    <div class="form-group mt-3 d-flex justify-content-center">
                        <button v-on:click="SearchOrder" class="btn btn-success">Найти договор</button>
                    </div>
                    <div v-if="error != null" class="text-center text-danger mt-1">
                        {{error}}
                    </div>
                </div>
                <div v-else>
                    <div class="form-group">
                        <label for="exampleFormControlInput1">Ваше имя</label>
                        <input v-model="name" class="form-control" id="exampleFormControlInput1" placeholder="Имя">
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlInput1">Телефон</label>
                        <input v-model="phone" class="form-control" id="exampleFormControlInput1" placeholder="7-900-999-99-99">
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlInput1">Email адрес</label>
                        <input v-model="email" type="email" class="form-control" id="exampleFormControlInput1" placeholder="address@example.com">
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlSelect1">Выберите тип помещения</label>
                        <select @change="onChangeCategory(selectCategory)" v-model="selectCategory" class="form-control">
                            <option v-for="(item, index) in categItems" v-bind:value="item">
                                {{item.Name}}
                            </option>
                        </select>
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlSelect1">Выберите сложность проекта</label>

                        <select v-model="selectedComplexity" class="form-control">
                            <option v-for="(item, index) in complexityItems" v-bind:key="item" v-bind:value="item">{{item.Name}}</option>
                        </select>

                    </div>
                    <div class="form-group mt-3" v-if="selectedComplexity != null">
                        <p>Стоимость ремонта составляет: <b>{{selectedComplexity.Price1.toLocaleString()}}</b> ₽/м2</p>
                    </div>
                    <div class="form-group mt-3">
                        <label for="customRange1" class="form-label">Площадь объекта: <b>{{square}} м2</b></label>
                        <div>
                            <input type="range" min="1" max="300" step="1" v-model="square" class="form-range" id="customRange1">
                        </div>
                    </div>
                    <div class="form-group mt-3">
                        <label for="exampleFormControlTextarea1">Примечание к заказу</label>
                        <textarea maxlength="300" v-model="description" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                    </div>
                    <div class="form-group mt-3">
                        <label>Выберите тип оплаты</label>
                        <select v-model="selectedPaymentType" class="form-control">
                            <option v-for="(item, index) in paymentsTypesItems" v-bind:key="item" v-bind:value="item">{{item.Name}} {{item.Procent}}%</option>
                        </select>
                        <div class="mt-1 text-center text-danger">
                            <span>Если вы уже вносили первоначальный взнос, то введите номер заказа, прописанный в договоре, при оплате вторичных и заключительных взносов!</span>
                        </div>
                    </div>
                </div>

                
                <div class="mt-3">
                    <div class="form-check mt-1 mb-1">
                        <input type="checkbox" v-model="isEnabledOfferta" class="form-check-input" id="exampleCheck1">
                        <label class="form-check-label" for="exampleCheck1">Я согласен с политикой <a target="_blank" class="about-service__address" href="/Oferta/Oferta">оферты o-sdn</a></label>
                    </div>
                </div>
                <div v-bind:class="[isEnabledOfferta == true ? '' : 'disabled-block']" class="form-group mt-5 d-flex justify-content-center">
                    <div v-if="selectedPaymentType != null && (selectedPaymentType.Id == 2 || selectedPaymentType.Id == 3)">                        
                        <button v-if="orderFinded != null" v-on:click="sendForm" type="submit" class="btn btn-success">Перейти к доплате <span v-if="selectedComplexity != null">{{this.orderFinded.sumPayment}}</span></button>
                    </div>
                    <div v-else>
                        <button v-on:click="sendForm" type="submit" class="btn btn-success">Перейти к оплате <span v-if="selectedComplexity != null">{{(selectedComplexity.Price1 * square / 100 * selectedPaymentType.Procent).toLocaleString()}}</span></button>
                    </div>
                </div>

            </form>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: "formcomponent",
        components: {
            axios
        },
        props: ['procent'],
        data() {
            return {

            }
        },
        computed: {
            // геттер вычисляемого значения получения процента
            GetProcent: function () {
                // `this` указывает на экземпляр vm
                return this.sumPay + (this.sumPay / 100 * this.procent)
            }
        },
        methods: {
            isEnabledOfferta: false,
            isEnabledOffertaUkassa: false,
            sumPay: 1000,
            procent: 0 // Процент комиссии нашего сервиса
        },
        mounted() {

        },
    }
</script>