import api from "./index"

export const getAllCards = async () => {
const {data} = await api.get("/cards")
return data 
}
