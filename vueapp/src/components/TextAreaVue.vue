<template>
    <textarea v-model="text"
              placeholder="[Shift] + <ENTER> for multi-line ..."
              outlined
              single-line
              dense
              hide-details
              rows="2"
              auto-grow
              @keydown.enter.shift.exact.prevent="text += '\n'"
              class="termino-input"
              wrap="hard">
    </textarea> <!-- @keydown.enter.exact.prevent="sendMessage" -->
</template>

<script>
import { defineComponent, ref } from 'vue';

export default defineComponent({
  setup() {
    const text = ref(0);
    const sendMessage = () => {
      if (!text.value) return;
      // your send message logic
    };

    return {
      text,
      sendMessage,
    };
  },
});
</script>