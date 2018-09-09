using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.Models;
using Newtonsoft.Json;

public class PodClient {
    const string NAMESPACE = "netug";

    public async Task KillRandomPod() {
        try {
            var rng = new Random();
            var pods = await GetPortalPods();
            var pod = pods.ElementAt(rng.Next(0, pods.Count()));
            await KillPod(pod.Metadata.Name);
        } catch {}
    }
    private async Task<IEnumerable<V1Pod>> GetPortalPods()
    {
        var client = new Kubernetes(Config());
        var list = await client.ListNamespacedPodAsync(NAMESPACE, labelSelector:"app=netug-portal-api");
        
        return list.Items;
    }

    private Task KillPod(string podName) {
        var client = new Kubernetes(Config());
        return client.DeleteNamespacedPodAsync(
            new V1DeleteOptions(apiVersion: "v1"), podName, NAMESPACE);
    }

    private KubernetesClientConfiguration Config() {
        //return KubernetesClientConfiguration.InClusterConfig();
        return KubernetesClientConfiguration.BuildConfigFromConfigFile();
    }
}