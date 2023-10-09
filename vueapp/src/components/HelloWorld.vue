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
            Note: There is bugs. I am aware of them. Creating this has been a rewarding opportunity to explore JS terminal console interfaces and challenges, as well as some .NET concepts, and other approaches to reimplimenting.
            -Boundary checking being one of them. see the README.MD file

        </div>
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
                loading: true,
                post: null
            };
        },
    });
</script>