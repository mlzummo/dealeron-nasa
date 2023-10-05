<script lang="ts">

    import VueCommand, { createStdout } from "vue-command";
    import "vue-command/dist/vue-command.css";

    export default {
        components: {
            VueCommand,
        },

        data: () => ({
            commands: {
                "hello-world": () => createStdout("Hello world"),
            },
        }),
    };
</script>

<template>
    <vue-command id="terminal" :commands="commands" />
</template>

<style>
    #terminal {
        height: 500px;
    }
</style>

