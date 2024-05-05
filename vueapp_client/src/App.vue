<template>
  <div>
    <PublicacionItem :publicaciones="publicaciones"
                     @nuevaPublicacionAgregada="actualizarPublicaciones"
                     @publicacionEditada="actualizarPublicaciones"
                     @publicacionEliminada="actualizarPublicaciones"/>
  </div>
</template>

<script>
import axios from 'axios';
import PublicacionItem from './components/PublicacionItem.vue'

export default {
  name: 'App',
  components: {
    PublicacionItem
  },
  data() {
    return {
      publicaciones: []
    }
  },
  created() {
    this.fetchPublicaciones();
  },
  methods: {
    async fetchPublicaciones() {
      try {
        var asd = process.env.VUE_APP_API_URL;
        console.log(asd);
        const response = await axios.get(process.env.VUE_APP_API_URL);
        this.publicaciones = response.data.publicaciones;
      } catch (error) {
        console.error('Error al obtener las publicaciones:', error);
      }
    },
    async actualizarPublicaciones() {
      this.fetchPublicaciones();
    }
  }
}
</script>
