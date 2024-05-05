import axios from 'axios';

const baseURL = 'http://localhost:5199/api/Publicacion';

export async function insertarPublicacion(nuevaPublicacion) {
  try {
    const response = await axios.post(baseURL, nuevaPublicacion);
    return response.data;
  } catch (error) {
    console.error("Error al agregar la publicación:", error);
    throw error;
  }
}

export async function editarPublicacion(id, publicacionEditada) {
  console.log("id a editar: ", id & "publicacion editada: ", publicacionEditada);
  try {
    const response = await axios.put(`${baseURL}/${id}`, publicacionEditada);
    return response.data;
  } catch (error) {
    console.error("Error al editar la publicación:", error);
    throw error;
  }
}

export async function eliminarPublicacion(id) {
  try {
    const response = await axios.delete(`${baseURL}/${id}`);
    return response.data;
  } catch (error) {
    console.error("Error al eliminar la publicación:", error);
    throw error;
  }
}
