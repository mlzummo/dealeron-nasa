<style>
    @import url(https://fonts.googleapis.com/css?family=Open+Sans:400italic);

    blockquote {
        /*        font-size: 1.4em;*/
        /*width: 60%;*/
        margin: 50px auto;
        font-family: Open Sans;
        font-style: italic;
        /*color: #555555;*/
        padding: 1.2em 30px 1.2em 75px;
        /*border-left: 8px solid #78C0A8;*/
        border-left: 8px solid #231f1f;
        border-left: 8px solid #474747;
        line-height: 1.6;
        position: relative;
        /*background: #EDEDED;*/
    }

        blockquote::before {
            font-family: Arial;
            content: "\201C";
            /*color: #78C0A8;*/
            /*color: #808080;*/
            color: red;
            font-size: 4em;
            position: absolute;
            left: 10px;
            top: -10px;
        }

        blockquote::after {
            content: '';
        }

        blockquote span {
            display: block;
           /* color: #333333;*/
            font-style: normal;
            font-weight: bold;
            margin-top: 1em;
        }
</style>
<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <blockquote>
                Space is for everybody. It's not just for a few people in 
                science or math, or for a select group of astronauts. 
                
                That's our new frontier out there, and it's everybody's business to know about space.
                
                <span>Christa McAuliffe, teacher and Challenger astronaut</span>
            </blockquote>
            <!--NASA : Mars Mission Control. Type "help" for a list of commands to-->
        </div>

<!--        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast in post" :key="forecast.date">
                        <td>{{ forecast.date }}</td>
                        <td>{{ forecast.temperatureC }}</td>
                        <td>{{ forecast.temperatureF }}</td>
                        <td>{{ forecast.summary }}</td>
                    </tr>
                </tbody>
            </table>
        </div>-->
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type Forecasts = {
        date: string
    }[];

    interface Data {
        loading: boolean,
        post: null | Forecasts
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as Forecasts;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>