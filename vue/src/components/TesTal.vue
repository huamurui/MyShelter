<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <table>
                <tbody>
                    <tr v-for="testal in post" :key="testal.id">
                        <td>{{ testal.id }}</td>
                        <td>{{ testal.nama }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <button @click="AxiosTest">axios≤‚ ‘</button>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type TesTal = {
        date: string
    }[];

    interface Data {
        loading: boolean,
        post: null | TesTal
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            AxiosTest(): void {
                axios({
                    method: 'post',
                    url: '/api/testal/postone',
                    data: {
                        id: 7,
                        nama:"dio",
                    }
                });
            },
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('api/testal/getall')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json as TesTal;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>