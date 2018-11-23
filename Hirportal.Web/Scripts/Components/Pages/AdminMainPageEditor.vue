<template>
    <div>
        <h2 class="mt-2">Főoldal szerkesztő</h2>
        <div class="row">
            <div class="col-md-9">
                <edit-articles-block v-for="block in blocks"
                                     :key="block.id"
                                     v-on:remove="removeBlock(block.id)"
                                     v-on:addCell="openAddNewCellModal(block.id)"
                                     v-bind:block="block"
                                     v-bind:allArticles="allArticles">
                </edit-articles-block>
                <div class="form-group d-flex">
                    <input placeholder="Új cikk blokk" v-model="newBlockName" class="form-control mr-2" />
                    <button class="btn btn-outline-info" @click="addBlock">Blokk hozzáadása</button>
                </div>
                <button class="btn btn-outline-info" @click="saveChanges">Változtatások mentése</button>
            </div>
        </div>
        <basic-modal ref="addNewCellModal" @ok="addNewCell()" :width="'500px'" :positiveButtonText="Hozzáadás" :hasNegativeButton="true">
            <h3 slot="header">Cikk keresés</h3>
            <div slot="body">
                <v-select v-model="newCellArticle" label="title" :options="allArticles"></v-select>
            </div>
        </basic-modal>
    </div>
</template>

<script>
    import { config } from '../../config';
    import { store } from '../../store';
    import axios from 'axios';
    import EditArticlesBlock from '../Molecules/EditArticlesBlock';
    import BasicModal from '../Molecules/BasicModal';
    import vSelect from 'vue-select';

    export default {
        components: {
            EditArticlesBlock,
            BasicModal,
            vSelect
        },
        data: function () {
            return {
                blocks: [],
                newBlockName: "",
                allArticles: [],
                activeBlockId: null,
                newCellArticle: null
            }
        },
        mounted() {
            axios
                .get(config.apiRoot + '/mainpage')
                .then(response => {
                    this.blocks = response.data.blocks;
                });

            axios({
                method: 'get',
                url: config.apiRoot + '/admin/all-articles',
                headers: {
                    "Authorization": `Bearer ${store.state.loginInfo.userToken}`
                }
            }).then(res => {
                this.allArticles = res.data;
                console.log(res.data);
            }).catch(err => {
                console.log(err.response);
            });
        },
        methods: {
            addBlock() {
                this.blocks.push({
                    name: this.newBlockName,
                    cells: [],
                    isLeadBlock: false,
                    id: (Math.floor(Math.random() * 100000000)).toString()
                });
                this.newBlockName = "";
            },
            saveChanges() {

            },
            removeBlock(id) {
                let index = this.blocks.findIndex(x => x.id == id);
                this.$delete(this.blocks, index);
            },
            openAddNewCellModal(id) {
                this.activeBlockId = id;
                this.$refs.addNewCellModal.show();
            },
            addNewCell() {
                let block = this.blocks.find(x => x.id == this.activeBlockId);
                block.cells.push({
                    article: this.newCellArticle,
                    displayIndex: 0,     
                    cellSize: 0
                });

                this.activeBlockId = null;
                this.newCellArticle = null;
            }
            
        }
    }
</script>