﻿<script lang="ts">
// Termino.js - Terminal App Demo (Basic)
import {Termino} from 'https://cdn.jsdelivr.net/gh/MarketingPipeline/Termino.js@v1.0.0/dist/termino.min.js';
import TextAreaVue from './TextAreaVue.vue'


/*    export default {
        components: {
            Termino,
        },

        data: () => ({
            commands: {
                "hello-world": () => createStdout("Hello world"),
            },
        }),

        methods: () => ({
            async init: () => ({
                let term2 = Termino(document.getElementById("Example_Terminal_2"));
            })
        })
    };*/


    import { defineComponent } from 'vue';

    interface Data {
        loading: boolean,
        post: null
    }
    export default defineComponent({
        components: {
            TextAreaVue,
        },
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        mounted() {
            // initialize a Terminal via Termino.js

           
            let term2 = Termino(document.getElementById("termino"))

            help();


            async function help() { // todo: mount these on vue methods

/*                const msg = [
                    'Welcome to NASA Mars Mission Control!\n',
                    '1. Print Hello World\n',
                    '2. Add Two Numbers\n',
                    '3. Initialize Map (DOES NOT WORK)\n',
                    '4. Enter Rover Instructions',
                    'test. Start Test'
                ];*/

                const msg = [
                    'Welcome to NASA Mars Mission Control!\n',
                    'test. type "test" to enter control block\n'
                ];

                msg.forEach((line) => {
                    term2.output(line);
                }) 

            }

            async function test() { // // todo: mount these on vue methods

                let input = await term2.input("Enter Input: (Copy and paste the block from below)");
                let response = await send(input);

                console.log(response)
                term2.output("Output:")
                response.forEach((obj: any) => {
                    let arr = [obj.x, obj.y, obj.direction];
                    term2.output(arr.join(' '));
                });
                setTimeout(basicTerminalApp, input)

            } // end test

            async function send(data: String) { // todo: make this a more generalized function (this is quick an dirty)
                try {
                    const response = await fetch('mission',
                        {
                            method: 'POST',
                            headers: {
                                'Accept': 'application/json',
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(data)
                        }
                    );
                    return response.json(); // return response from mars
                } catch (error) {
                    console.error('Error: (re)enter');
                }
            }


            async function basicTerminalApp() {
                
                let input = await term2.input("")

                switch (input) {
                    case "test": test();
                        break;
                    case "help": help();
                        break;
                    default:
/*                        setTimeout(basicTerminalApp, input)
*/                        break;

                }

                setTimeout(basicTerminalApp,input) // wait for next input (dirty hack)
            }

            basicTerminalApp() // init the app since we are in a "global scope" .. i am using a non vue plugin here =/
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            //this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
        },
    });
</script>

<style lang="css" scoped >
    /* styling used  for the Termino.js - terminal demo(s) */
    .repl {
        text-shadow: none;
        /*        color: #333;
        background: #f8f8f8;*/
        color: #FFF;
        background: #181818;
        padding: 0;
        text-align: left;
        width: 600px;
        margin: 50px auto;
        border-radius: 3px;
        border: 1px solid #ddd;
        overflow: hidden;
    }

    .repl code {
        height: 200px;
        overflow-y: scroll;
    }

    pre {
        margin: 0;
    }

    .termino-console {
        padding: 11px 16px;
        display: block;
    }

    .termino-input-container {
        display: flex;
    }

        .termino-input-container > * {
            outline: none;
            border: none;
            white-space: pre-wrap;
            font-family: monospace;
            /*        color: #444 ;
        background: #f0f0f0 ;*/
            color: #FFF;
            background: #202020;
            min-height: 14px; /* minimum one line */
            padding: 10px;
            margin: 0;
            border-radius: 0 0 3px 3px;
            border-top: 1px solid #ddd;
        }

    .termino-input {
        flex: 1;
        height: 100%; /* start off one line tall */
        padding-left: 0;
    }

    .termino-prompt {
        
        font-weight: bold; /* do we need <a>?*/
     
        padding: 8px 10px;
    }

    @media screen and (max-width : 800px) {

    .repl {
            width: 100%;
        }
    }

    .lua {
        resize: none;
        overflow: hidden;
    }

    pre {
        word-break: break-all;
        white-space: pre-line;
    }

    .repl code {
        scroll-behavior: smooth;
    }

    /* hide scrollbar but allow scrolling */
    .repl code {
        -ms-overflow-style: none; /* for Internet Explorer, Edge */
        scrollbar-width: none; /* for Firefox */
        overflow-y: scroll;
    }

        .repl code::-webkit-scrollbar {
            display: none; /* for Chrome, Safari, and Opera */
        }


    .loading:after {
        content: ' .';
        animation: dots 1s steps(5, end) infinite;
    }

/*    @keyframes dots {
        0%, 20% {
            color: rgba(0,0,0,0);
            text-shadow: .25em 0 0 rgba(0,0,0,0), .5em 0 0 rgba(0,0,0,0);
        }

        40% {
            color: white;
            text-shadow: .25em 0 0 rgba(0,0,0,0), .5em 0 0 rgba(0,0,0,0);
        }

        60% {
            text-shadow: .25em 0 0 white, .5em 0 0 rgba(0,0,0,0);
        }

        80%, 100% {
            text-shadow: .25em 0 0 white, .5em 0 0 white;
        }
    }*/
</style>
<template>
    <div id="termino" >
        <div class="repl">
            <pre><code class="termino-console"></code></pre>
            <div class="termino-input-container">
                <div>
                    <label class="termino-prompt" id="termino-prompt" for="termino-input">→ </label>
                </div>
                <TextAreaVue id="termino-input" rows="2" wrap="hard"/>
                <!-- <textarea class="termino-input" rows="1" wrap="hard"></textarea> -->
            </div>
        </div>
    </div>
</template>
