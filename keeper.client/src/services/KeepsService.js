import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{

  async getKeeps() {
    // debugger
    // AppState.keeps = []
    const res = await api.get('api/keeps')
    logger.log('getKeeps' ,res.data)
    AppState.keeps = res.data
  }

  async getById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`)
    logger.log(res)
  }

  async getVaultKeeps(vaultId) {
    AppState.vaultKeeps = []
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    logger.log(res.data)
    AppState.vaultKeeps = res.data
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log('createKeep', res)
    AppState.profileKeeps.unshift(res.data)
  }

  async deleteKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    logger.log('deleteKeep', res)
    AppState.keeps = AppState.keeps.filter(k => k.id !== keepId)
    AppState.vaultKeeps = AppState.vaultKeeps.filter(k => k.keepId !== keepId)
  }
  async deleteProfileKeep(keepId) {
    const res = await api.delete(`api/keeps/${keepId}`)
    logger.log('deleteProfileKeep', res)
    AppState.profileKeeps = AppState.profileKeeps.filter(k => k.id !== keepId)
  }

  // async addView(editable) {
  //   const res = await api.put(`api/keeps/${editable.id}`, editable)
  //   logger.log(res)
  // }
}

export const keepsService = new KeepsService()