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
        const response = await axios.get('http://localhost:5199/api/Publicacion');
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
