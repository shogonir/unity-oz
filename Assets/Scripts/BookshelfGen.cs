using UnityEngine;
using System.Collections;

public class BookshelfGen : MonoBehaviour {

    public GameObject ele;
    public GameObject book;

    public int id = 0;
    public int max_eles = 60;
    public float radius = 20;
    public float base_y = -3.0f;

    int max_books = 1;

    int num_eles = 0;
    float depth = 0.3f;
    float thick = 0.02f;
    float height = 0.4f;
    float ele_width;
    float rotate;
    bool[] exists;

    bool init_exists ()
    {
        int index = 0;
        bool tf = true;
        while ((tf && index < max_eles - 5) || (!tf && index < max_eles - 8))
        {
            int rand = tf ? Random.Range(3, 5) : Random.Range(2, 5);
            for (int i = index; i < index + rand; i++)
            {
                exists[i] = tf;
            }
            tf = tf ? false : true;
            index += rand;
        }
        for (int i = index; i < max_eles; i++) exists[i] = tf;
        return true;
    }

    bool true_exists ()
    {
        for (int i=0; i< max_eles; i++)
        {
            exists[i] = true;
        }
        return true;
    }

	void Start () {
        float rad = Mathf.PI / max_eles;
        ele_width = (depth / 2 + radius) * Mathf.Tan(rad) * 2.0f;
        rotate = 0.1f * (Random.value - 0.5f);
        exists = new bool[max_eles];
        bool tf = id!=0 ? init_exists() : true_exists();
    }
	
	void Update () {
	    if (num_eles < max_eles && Time.frameCount % 8 == 0)
        {
            float rad = 2.0f * Mathf.PI * num_eles / max_eles;
            Vector3 pos = new Vector3(radius * Mathf.Cos(rad), base_y, radius * Mathf.Sin(rad));
            BookshelfEle(height, pos);
            BookshelfEle(0, pos);
            BookshelfEle(-height, pos);
            Book();
            Bookend(pos, rad);
            num_eles += 1;
        }
        transform.Rotate(0, rotate, 0);
	}

    void Book ()
    {
        if (exists[num_eles])
        {
            for (int num_books = 0; num_books < max_books; num_books++)
            {
                float rad = 2.0f * Mathf.PI * (1f * num_eles / max_eles + ((num_books+0.5f-max_books/2f) / max_books / max_eles));
                Vector3 pos = new Vector3((radius+0.0f/*3f*/) * Mathf.Cos(rad), base_y, (radius+0.0f/*3f*/) * Mathf.Sin(rad));
                GameObject obj = (GameObject)Instantiate(book, Vector3.zero, transform.rotation);
                obj.transform.parent = transform;
                obj.transform.localPosition = pos;
                obj.transform.LookAt(new Vector3(0, base_y, 0));
                if (Random.value < 0.5f) obj.transform.Rotate(0, 180, 0);
                obj.transform.localScale = new Vector3(ele_width * 1.0f / max_books - 0.07f, height*2f*16f, 0.1f);
                Material mat = obj.GetComponent<SpriteRenderer>().material;
                mat.color = RadColor(rad);
            }
        }
    }

    Color RadColor (float rad)
    {
        float noam_rad = rad / (2.0f * Mathf.PI);
        if (noam_rad < 1.0f / 6)
        {
            return new Color(6f*(noam_rad-0f/6f), 0, 1);
        }
        else if (noam_rad < 2.0f / 6)
        {
            return new Color(1, 0, 1f - 6f * (noam_rad-1f/6f));
        }
        else if (noam_rad < 3.0f / 6)
        {
            return new Color(1, 6f * (noam_rad -2f/6f), 0);
        }
        else if (noam_rad < 4.0f / 6)
        {
            return new Color(1f - 6f * (noam_rad-3f/6f), 1, 0);
        }
        else if (noam_rad < 5.0f / 6)
        {
            return new Color(0, 1, 6f * (noam_rad -4f/6f));
        }
        else
        {
            return new Color(0, 1f - 6f * (noam_rad-5f/6f), 1);
        }
    }

    void BookshelfEle (float h, Vector3 pos)
    {
        if (exists[num_eles] == true)
        {
            pos += new Vector3(0, h, 0);
            GameObject obj = (GameObject)Instantiate(ele, new Vector3(0, base_y, 0), transform.rotation);
            obj.transform.parent = transform;
            obj.transform.localPosition = pos;
            obj.transform.LookAt(new Vector3(0, base_y + h, 0));
            obj.transform.localScale = new Vector3(ele_width, thick, depth);
        }
    }

    void Bookend (Vector3 pos, float rad)
    {
        bool cond1 = num_eles < max_eles - 1 && exists[num_eles] && exists[num_eles + 1] == false;
        bool cond2 = num_eles > 0            && exists[num_eles] && exists[num_eles - 1] == false;
        if (cond1 || cond2)
        {
            GameObject obj = (GameObject)Instantiate(ele, new Vector3(0, base_y, 0), transform.rotation);
            obj.transform.parent = transform;
            obj.transform.localPosition = pos;
            obj.transform.LookAt(new Vector3(0, base_y, 0));
            obj.transform.localScale = new Vector3(thick, height*2+thick, depth);
            rad += cond1 ? Mathf.PI * 0.5f : -Mathf.PI * 0.5f;
            pos += new Vector3(ele_width / 2 * Mathf.Cos(rad), 0, ele_width / 2 * Mathf.Sin(rad));
            obj.transform.localPosition = pos;
        }
    }
}
