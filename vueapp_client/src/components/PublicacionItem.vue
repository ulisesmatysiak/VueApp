<template>
  <div class="container">
    <h1 class="display-4 text-center">Listado de Publicaciones</h1>
    <div class="row">
      <div
        v-for="publicacion in publicaciones"
        :key="publicacion.idPublicacion"
        class="col-md-4 mb-4"
      >
        <div class="card">
          <img
            :src="`/img/${publicacion.imagenes}`"
            class="card-img-top"
            alt="Imagen de la publicación"
          />
          <div class="card-body">
            <h5 class="card-title">{{ publicacion.descripcion }}</h5>
            <p class="card-text">{{ publicacion.idPublicacion }}</p>
            <p class="card-text">{{ publicacion.tipoPropiedad }}</p>
            <p class="card-text">{{ publicacion.tipoOperacion }}</p>
            <p class="card-text">{{ publicacion.ambientes }} Ambientes</p>
            <p class="card-text">{{ publicacion.metrosCuadrados }} m²</p>
            <p class="card-text">
              {{ publicacion.antiguedad }} años de antigüedad
            </p>
            <p class="card-text">{{ publicacion.coordenadasUbicacion }}</p>
            <div class="text-center">
              <button
                class="btn btn-primary mr-2"
                @click="editarPublicacion(publicacion)"
              >
                Editar
              </button>
              <button
                class="btn btn-danger"
                @click="eliminarPublicacion(publicacion.idPublicacion)"
              >
                Eliminar
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="text-center mt-4">
      <form v-if="!editando" @submit.prevent="insertarPublicacion()">
        <input
          v-model="nuevaPublicacion.descripcion"
          type="text"
          class="form-control mb-2"
          placeholder="Descripción"
        />
        <input
          v-model="nuevaPublicacion.tipoPropiedad"
          type="text"
          class="form-control mb-2"
          placeholder="Tipo de Propiedad"
        />
        <input
          v-model="nuevaPublicacion.tipoOperacion"
          type="text"
          class="form-control mb-2"
          placeholder="Tipo de Operación"
        />
        <input
          v-model="nuevaPublicacion.ambientes"
          type="number"
          class="form-control mb-2"
          placeholder="Ambientes"
        />
        <input
          v-model="nuevaPublicacion.metrosCuadrados"
          type="number"
          class="form-control mb-2"
          placeholder="Metros Cuadrados"
        />
        <input
          v-model="nuevaPublicacion.antiguedad"
          type="number"
          class="form-control mb-2"
          placeholder="Antigüedad"
        />
        <input
          v-model="nuevaPublicacion.coordenadasUbicacion"
          type="text"
          class="form-control mb-2"
          placeholder="Coordenadas de Ubicación"
        />
        <input
          v-model="nuevaPublicacion.imagenes"
          type="text"
          class="form-control mb-2"
          placeholder="URL de la imagen"
        />
        <button type="submit" class="btn btn-success">
          Agregar Publicación
        </button>
      </form>

      <div v-if="editando" class="mt-2">
        <h3>Editar Publicación</h3>
        <form @submit.prevent="guardarEdicion()">
          <input
            v-model="publicacionEditada.descripcion"
            type="text"
            class="form-control mb-2"
            placeholder="Descripción"
          />
          <input
            v-model="publicacionEditada.tipoPropiedad"
            type="text"
            class="form-control mb-2"
            placeholder="Tipo de Propiedad"
          />
          <input
            v-model="publicacionEditada.tipoOperacion"
            type="text"
            class="form-control mb-2"
            placeholder="Tipo de Operación"
          />
          <input
            v-model="publicacionEditada.ambientes"
            type="number"
            class="form-control mb-2"
            placeholder="Ambientes"
          />
          <input
            v-model="publicacionEditada.metrosCuadrados"
            type="number"
            class="form-control mb-2"
            placeholder="Metros Cuadrados"
          />
          <input
            v-model="publicacionEditada.antiguedad"
            type="number"
            class="form-control mb-2"
            placeholder="Antigüedad"
          />
          <input
            v-model="publicacionEditada.coordenadasUbicacion"
            type="text"
            class="form-control mb-2"
            placeholder="Coordenadas de Ubicación"
          />
          <input
            v-model="publicacionEditada.imagenes"
            type="text"
            class="form-control mb-2"
            readonly="true"
            placeholder="URL de la imagen"
          />
          <button type="submit" class="btn btn-primary">Guardar</button>
          <button
            type="button"
            class="btn btn-secondary ml-2"
            @click="cancelarEdicion()"
          >
            Cancelar
          </button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import {
  insertarPublicacion,
  editarPublicacion,
  eliminarPublicacion,
} from "../utils/api";

export default {
  name: "PublicacionItem",
  props: {
    publicaciones: Array,
  },
  data() {
    return {
      nuevaPublicacion: {
        descripcion: "",
        tipoPropiedad: "",
        tipoOperacion: "",
        ambientes: 0,
        metrosCuadrados: 0,
        antiguedad: 0,
        coordenadasUbicacion: "",
        imagenes: "",
      },
      publicacionEditada: {
        idPublicacion: 0,
        descripcion: "",
        tipoPropiedad: "",
        tipoOperacion: "",
        ambientes: 0,
        metrosCuadrados: 0,
        antiguedad: 0,
        coordenadasUbicacion: "",
        imagenes: "",
      },
      editando: false,
    };
  },
  methods: {
    async insertarPublicacion() {
      try {
        const response = await insertarPublicacion(this.nuevaPublicacion);
        console.log("Nueva publicación agregada:", response);
        this.$emit("nuevaPublicacionAgregada", response);
        this.nuevaPublicacion = {};
      } catch (error) {
        console.error("Error al agregar la publicación:", error);
      }
    },
    async editarPublicacion(publicacion) {
      console.log(publicacion);
      this.publicacionEditada = { ...publicacion };
      this.editando = true;
    },
    async guardarEdicion() {
      try {
        const response = await editarPublicacion(
          this.publicacionEditada.idPublicacion,
          this.publicacionEditada
        );
        console.log("Publicación editada:", response);
        this.$emit("publicacionEditada", response);
        this.publicacionEditada = {};
        this.editando = false;
      } catch (error) {
        console.error("Error al editar la publicación:", error);
      }
    },
    async cancelarEdicion() {
      this.publicacionEditada = {};
      this.editando = false;
    },
    async eliminarPublicacion(idPublicacion) {
      console.log("id publicacion a eliminar:", idPublicacion);
      try {
        const response = await eliminarPublicacion(idPublicacion);
        console.log("Publicación eliminada:", response);
        this.$emit("publicacionEliminada", idPublicacion);
      } catch (error) {
        console.error("Error al eliminar la publicación:", error);
      }
    },
  },
};
</script>

<style scoped></style>
