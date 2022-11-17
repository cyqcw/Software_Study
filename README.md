## Software_Study

## Store code and projects in the course.

## 仅作为学习用途

  cyqcw444444@gmail.com
  
  cyqcw@foxmail.com


'''#include <stdio.h>
#include <stdlib.h>
#define MAX 100
typedef struct node{
    int ver,weight;    //  
    struct node* next;
}LinkNode;

typedef struct{ //  图的邻接表结构
    int verNum,edgeNum;
    char vers[MAX]; //  顶点集
    LinkNode* AdjList[MAX]; //  邻接表
}GraphAdjList;

void CreatGraphAdjList(GraphAdjList* G){
    // G->AdjList=(LinkNode**)malloc(G->verNum*sizeof(LinkNode*));  //  领接表申请不知道对不对
    printf("Please enter the number of vertexes and edges : \n");
    scanf("%d%d",&G->verNum,&G->edgeNum);
    for(int i=0;i<G->verNum;i++){   //  领接表初始化
        G->AdjList[i]=(LinkNode*)malloc(sizeof(LinkNode));
        G->AdjList[i]->ver=i;   //  索引存入领接表表头
        G->AdjList[i]->next=NULL;
    }

    printf("Please enter the vertexes : \n");
    scanf("%*c");   //  略去\n
    for(int i=0;i<G->verNum;i++){
        scanf("%c",&G->vers[i]);   //  读入点集
    }

    printf("Please enter the edges : \n");  //  输入边格式为"0 0 1"
    int x,y,w;
    for(int i=0;i<G->edgeNum;i++){  //  头插将边加入邻接表
        scanf("%d%d%d",&x,&y,&w);
        LinkNode* p=(LinkNode*)malloc(sizeof(LinkNode));
        p->ver=y;
        p->weight=w;
        p->next=G->AdjList[x]->next;
        G->AdjList[x]->next=p;
        LinkNode* q=(LinkNode*)malloc(sizeof(LinkNode));
        q->ver=x;
        q->weight=w;
        q->next=G->AdjList[y]->next;
        G->AdjList[y]->next=q;
    }
}

void PrintGraph(GraphAdjList* G){
    for(int i=0;i<G->verNum;i++){
        printf("%c :",G->vers[G->AdjList[i]->ver]);
        LinkNode* p=G->AdjList[i]->next;
        while(p){
            printf(" %c",G->vers[p->ver]);
            p=p->next;
        }printf("\n");
    }
}

//  辅助函数
int IsIn(int* a,int len,int x){
    for(int i=0;i<len;i++)
        if(a[i]==x)return 1;
    return 0;
}

/*写错了，要用深搜*/
int BFS(GraphAdjList* G,int x,int y,int k){    //  找到k长的路径
    int used[100];  //如果该点有用到加入到这里面
    for(int i=0;i<G->verNum;i++)used[i]=-1; //  初始化为-1为了避免混淆
    int index=0,start=0,end=0,layer=0;
    used[index++]=x;
    while(index<G->verNum){
        end=index;  //  获取此层最新进度
        while(start<end){    //  把start->end层的节点加入队列
            /*判断start这一点是否满足条件*/
            // if(G->AdjList[start]->ver==k && layer==k)return 1;
            // else if(G->AdjList[start]->ver==k)return 0;
            LinkNode* p=G->AdjList[start]->next;
            while(p){   /*在start这一层把所有邻接点加入队列中*/
                if(!IsIn(used,index,p->ver)){   /*不在已使用的节点中*/
                    used[index++]=p->ver;
                }p=p->next;
            }
            
            /*TEST*/
            for(int i=0;i<index;i++){
                printf("%c ",G->vers[used[i]]);
            }printf("\n");
            /*TEST*/
            start++;
        }layer++;   /*完成一层加入*/



    }
    return 0;
}

int DFS(){
    return 1;
}
int main(){
    GraphAdjList* G=(GraphAdjList*)malloc(sizeof(GraphAdjList));
    CreatGraphAdjList(G);
    PrintGraph(G);
    printf("%d\n",BFS(G,0,3,3));
    return 0;
}
'''
